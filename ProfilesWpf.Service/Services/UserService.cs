using Mapster;
using Newtonsoft.Json;
using ProfilesWpf.Data.IRepositories;
using ProfilesWpf.Data.Repositories;
using ProfilesWpf.Domain.Entities;
using ProfilesWpf.Service.Interfaces;
using ProfilesWpf.Service.Models;
using ProfilesWpf.Service.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExamWithDesktop.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient httpClient;

        private readonly IStudentRepository studentRepository;
        private readonly IAttachmentRepository attachmentsRepository;
        public StudentService()
        {
            attachmentsRepository = new AttachmentRepository();
            studentRepository = new StudentRepository();
            httpClient = new HttpClient();
        }

        public async Task<Student> CreateAsync(StudentForCreation studentForCreation)
        {
            string newStudent = JsonConvert.SerializeObject(studentForCreation);
            var requestContent = new StringContent
                (newStudent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(Constants.BASE_URL, requestContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();


                var student = studentForCreation.Adapt<Student>();
                student.Id = JsonConvert.DeserializeObject<Student>(content).Id;

                await studentRepository.CreateAsync(studentForCreation.Adapt(student));

                await studentRepository.SaveAsync();

                return student;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await httpClient.DeleteAsync(Constants.BASE_URL + id);
            bool Student = await studentRepository.DeleteAsync(u => u.Id == id);
            await studentRepository.SaveAsync();

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("admin:12345")));

            var response = await httpClient.GetAsync(Constants.BASE_URL);

            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<IEnumerable<Student>>(await response.Content.ReadAsStringAsync())
                : null;
        }

        private async Task<Student> GetFromDataBaseAsync(long id)
        {
            return await studentRepository.GetAsync(u => u.Id == id);
        }

        public async Task<Student> GetAsync(long id)
        {
            var response = await httpClient.GetAsync(Constants.BASE_URL + id);

            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Student>(await response.Content.ReadAsStringAsync()) : null;
        }


        public async Task<Student> UpdateAsync(long id, StudentForCreation StudentForCreation)
        {
            string newStudentAsJson = JsonConvert.SerializeObject(StudentForCreation);

            StringContent responseContent = new StringContent(newStudentAsJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(Constants.BASE_URL + id, responseContent);


            if (response.IsSuccessStatusCode)
            {
                var Student = await GetFromDataBaseAsync(id);
                studentRepository.Update(StudentForCreation.Adapt(Student));
                await studentRepository.SaveAsync();
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Student>(content);
            }

            return null;
        }

        public async Task UploadImageAsync(long id, string imagePath, string passportPath)
        {
            using (HttpClient client = new HttpClient())
            {
                MultipartFormDataContent formData = new MultipartFormDataContent();


                if (imagePath != null && passportPath != null)
                {
                    formData.Add(new StreamContent(File.OpenRead(imagePath)), "image", "image.png");
                    formData.Add(new StreamContent(File.OpenRead(passportPath)), "passport", "passport.png");

                    HttpResponseMessage response = await client.PostAsync(Constants.BASE_URL + "Attachments/" + id, formData);


                    var Student = JsonConvert.DeserializeObject<Student>(await client.GetStringAsync(Constants.BASE_URL + id));


                    var dbStudent = await studentRepository.GetAsync(u => u.Id == id);

                    if (dbStudent != null)
                    {
                        await attachmentsRepository.CreateAsync(new Attachments
                        {
                            Id = Student.Image.Id,
                            Name = imagePath.Replace(".png", ""),
                            Path = imagePath
                        });
                        await attachmentsRepository.SaveAsync();

                        await attachmentsRepository.CreateAsync(new Attachments
                        {
                            Id = Student.Passport.Id,
                            Name = passportPath.Replace(".png", ""),
                            Path = passportPath
                        });

                        await attachmentsRepository.SaveAsync();
                        dbStudent.ImageId = Student.ImageId;
                        dbStudent.PassportId = Student.PassportId;
                        await studentRepository.SaveAsync();
                    }
                }
            }
        }
    }
}
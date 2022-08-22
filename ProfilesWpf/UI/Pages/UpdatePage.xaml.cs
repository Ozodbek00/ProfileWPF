using ExamWithDesktop.Service.Services;
using ProfilesWpf.Service.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProfilesWpf.UI.Pages
{
    public partial class UpdatePage : Page
    {
        private string passportPath;
        private readonly StudentForCreation studentForCreation;
        private string portraitPath;
        private readonly StudentService studentService;

        public UpdatePage()
        {
            studentService = new StudentService();
            studentForCreation = new StudentForCreation();
            InitializeComponent();
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            long id;

            if (long.TryParse(SaveIdTextInp.Text, out id))
            {
                var student = await studentService.GetAsync(id);
                if (student != null)
                {
                    studentForCreation.FirstName = 
                        String.IsNullOrEmpty(SaveFirstNameInp.Text) ? student.FirstName : SaveFirstNameInp.Text;

                    studentForCreation.LastName = 
                        String.IsNullOrEmpty(SaveLastNameInp.Text) ? student.LastName : SaveLastNameInp.Text;

                    studentForCreation.Faculty = 
                        String.IsNullOrEmpty(SaveFacultyInp.Text) ? student.Faculty : SaveFacultyInp.Text;

                    await studentService.UpdateAsync(id, studentForCreation);

                    await studentService.UploadImageAsync(id, passportPath, portraitPath);

                    MessageBox.Show("Successfully updated");
                }

                else
                    MessageBox.Show("student not found");
            }
            else
                MessageBox.Show("Id should be a numeric");
        }

        private void PortraitBtn_Click(object sender, RoutedEventArgs e)
        {
            portraitPath = ChooseFile();
            PortraitImg.ImageSource = new BitmapImage(new Uri(portraitPath));

        }

        private void PassportBtn_Click(object sender, RoutedEventArgs e)
        {
            passportPath = ChooseFile();
            PassportImg.ImageSource = new BitmapImage(new Uri(passportPath));
        }

        private string ChooseFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.PNG,*.JPG;)|*.JPG;*.PNG";
            openFileDialog.InitialDirectory = Environment.GetFolderPath
                (Environment.SpecialFolder.MyPictures);


            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }
    }
}

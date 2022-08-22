using ExamWithDesktop.Service.Services;
using ProfilesWpf.Domain.Entities;
using ProfilesWpf.UI.Controls;
using ProfilesWpf.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProfilesWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread thread;
        IEnumerable<Student> allStudents;
        private StudentService studentService;
        private readonly UpdatePage updatePage;
        private readonly DeletePage deletePage;
        private readonly AddPage addPage;
        public MainWindow()
        {
            studentService = new StudentService();
            addPage = new AddPage();
            deletePage = new DeletePage();
            updatePage = new UpdatePage();
            InitializeComponent();
        }

        private void DelButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = deletePage;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = addPage;
        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            SudentsList.Items.Clear();

            string text = SearchTxt.Text.ToLower();

            var users = allStudents.Where(p => p.FirstName.ToLower().Contains(text)
                || p.LastName.ToLower().Contains(text) || p.Id.ToString() == text);

            SudentsList.Items.Clear();


            var thread = new Thread(async () =>
            {
                await LoadStudents(users);
            });
            thread.Start();
        }

        private async Task LoadStudents(IEnumerable<Student> students)
        {
            foreach (var Student in students)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    Button button = new Button()
                    {
                        Background = new SolidColorBrush(Color.FromRgb(38, 28, 44)),
                        Padding = new Thickness(0),
                        Height = 60,
                        BorderThickness = new Thickness(0),
                    };

                    button.Click += UserFullInfoButton_Click;
                    ProfileShortInfo shortInfo = new ProfileShortInfo();
                    shortInfo.NameTxt.Text = Student.FirstName + " " + Student.LastName;
                    shortInfo.Id = Student.Id;
                    shortInfo.StudentImg.ImageSource = Student.Image is not null
                        ? new BitmapImage(new Uri("https://talabamiz.uz/" + Student.Image.Path))
                        : new BitmapImage(new Uri("https://talabamiz.uz/Images//99daf8ac38de4433aa36a61baf4c9c4d.png"));

                    button.Content = shortInfo;

                    SudentsList.Items.Add(button);
                });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(async () =>
            {
                this.Dispatcher.Invoke(() => SudentsList.Items.Clear());

                allStudents = await studentService.GetAllAsync();
                await LoadStudents(allStudents);
            });

            thread.Start();
        }


        private async void UserFullInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            var shortInfo = button.Content as ProfileShortInfo;

            Student student = await studentService.GetAsync(shortInfo.Id);

            UpdatePage savePage = new UpdatePage();

            if (student != null)
            {
                savePage.SaveFirstNameInp.Text = student.FirstName;
                savePage.SaveLastNameInp.Text = student.LastName;
                savePage.SaveFacultyInp.Text = student.Faculty;
                savePage.SaveIdTextInp.Text = student.Id.ToString();

                savePage.PortraitImg.ImageSource = student.Image is not null
                            ? new BitmapImage(new Uri("https://talabamiz.uz/" + student.Image.Path))
                            : new BitmapImage(new Uri("https://talabamiz.uz/Images//99daf8ac38de4433aa36a61baf4c9c4d.png"));

                savePage.PassportImg.ImageSource = student.Passport is not null
                            ? new BitmapImage(new Uri("https://talabamiz.uz/" + student.Passport.Path))
                            : new BitmapImage(new Uri("https://talabamiz.uz/Images//99daf8ac38de4433aa36a61baf4c9c4d.png"));

                MainFrame.Content = savePage;
            }
            else
            {
                MessageBox.Show("Student not found");
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }
    }
}

using ExamWithDesktop.Service.Services;
using ProfilesWpf.Service.Models;
using System.Windows;
using System.Windows.Controls;

namespace ProfilesWpf.UI.Pages
{
    public partial class AddPage : Page
    {
        StudentService studentService;
        StudentForCreation studentForCreation;
        public AddPage()
        {
            studentService = new StudentService();
            studentForCreation = new StudentForCreation();
            InitializeComponent();
        }

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            studentForCreation.FirstName = SaveFirstNameInp.Text;
            studentForCreation.LastName = SaveLastNameInp.Text;
            studentForCreation.Faculty = SaveFacultyInp.Text;

            await studentService.CreateAsync(studentForCreation);
        }
    }
}

using ExamWithDesktop.Service.Services;
using System.Windows;
using System.Windows.Controls;

namespace ProfilesWpf.UI.Pages
{
    public partial class DeletePage : Page
    {
        StudentService studentService;
        public DeletePage()
        {
            studentService = new StudentService();
            InitializeComponent();
        }

        private async void DeteleBtn_Click(object sender, RoutedEventArgs e)
        {
            long id;
            if (long.TryParse(DeleteIdTextInp.Text, out id))
            {
                if (await studentService.DeleteAsync(id))
                    MessageBox.Show("Student deleted successfully");
                else
                    MessageBox.Show("No student was found");
            }
            else
                MessageBox.Show("Id should be a number");
        }
    }
}

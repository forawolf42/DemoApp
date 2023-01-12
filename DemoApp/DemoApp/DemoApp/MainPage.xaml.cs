using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ogr_no.Text))
            {
                await DisplayAlert("HATA", "NO BOŞ", "TAMAM");
                return;
            }
            Database data = new Database();
            await data.AddStudent(ogr_no.Text, ogr_name.Text,ogr_gender.SelectedItem.ToString());
        }
        private async void ogr_getir_btn_Clicked(object sender, EventArgs e)
        {
            Database data = new Database();
            var student = await data.GetStudent(ogr_no_get.Text);
            if (student != null) 
            {
                ogr_label.Text = $"Öğrenci İsmi:{student.StudentName}";
                gender_label.Text = $"Öğrenci Cinsiyet:{student.StudentGender}";
            }
            else
            {
                ogr_label.Text = $"Böyle bir öğrenci yok";
                gender_label.Text = $"";
            }
        }
    }
}

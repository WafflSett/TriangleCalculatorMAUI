using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using TriangleCalculatorMAUI.Classes;
using TriangleCalculatorMAUI.Popups;

namespace TriangleCalculatorMAUI
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Triangle myTriangle = new Triangle();

        public Triangle MyTriangle
        {
            get { return myTriangle; }
            set { myTriangle = value; OnPropertyChanged(nameof(MyTriangle)); }
        }

        public List<string> PickerOptions { get; set; } = new List<string>() {"Area", "Perimeter", "Angles" };
        public int SelectedIndex { get; set; } = -1;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void Calc_BTN_Clicked(object sender, EventArgs e)
        {
            if (SelectedIndex != -1 && MyTriangle.IsValidTriangle())
                await this.ShowPopupAsync(new PopupPage("Result", GetCalcResult()));
            else
                await this.ShowPopupAsync(new PopupPage("Error", "The triangle you entered isnt valid!"));
        }

        private void Clear_BTN_Clicked(object sender, EventArgs e)
        {
            MyTriangle = new Triangle();
            OnPropertyChanged(nameof(MyTriangle));
        }

        private string GetCalcResult() {
            switch (SelectedIndex)
            {
                case 0:
                    return $"{MyTriangle.Area}";
                case 1:
                    return $"{MyTriangle.S}";
                case 2:
                    return $"α={MyTriangle.Alpha}°, β={myTriangle.Beta}°, γ={MyTriangle.Gamma}°";
                default:
                    return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string tulajdonsagNev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
        }
    }

}

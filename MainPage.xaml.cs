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
        private int selectedIndex = -1;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; OnPropertyChanged(nameof(SelectedIndex)); }
        }


        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void Calc_BTN_Clicked(object sender, EventArgs e)
        {
            if (!MyTriangle.IsValidTriangle()) {
                await this.ShowPopupAsync(new PopupPage("Error", "The triangle you entered isnt valid!"));
                return;
            }
            if (SelectedIndex != -1){
                await this.ShowPopupAsync(new PopupPage("Result", GetCalcResult()));
                return;
            }
            await this.ShowPopupAsync(new PopupPage("Error", "Please select a calculation mode!"));
        }

        private void Clear_BTN_Clicked(object sender, EventArgs e)
        {
            MyTriangle = new Triangle();
            SelectedIndex = -1;
            //OnPropertyChanged(nameof(MyTriangle));
        }

        private string GetCalcResult() {
            switch (SelectedIndex)
            {
                case 0:
                    return $"A={MyTriangle.Area}";
                case 1:
                    return $"P={MyTriangle.S}";
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

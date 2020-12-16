using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace STT_Hope
{
    public partial class MainPage : MasterDetailPage
    {
        string[] ListNames = new string[]
        {
            "Book One",
            "Book Two",
            "Book Three",
            "Book Four",
            "Book Five",
            "Book Six",
            "Book Seven",
            "Book Eight",
            "Book Nine",
            "Book Ten",
        };
        string[] ListDetails = new string[]
        {
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
            "Book Description",
        };
        string[] ListImages = new string[]
        {
            "book.png",
            "book.png",
            "book.png",
            "book.png",
            "book.png",
            "book.png",
            "book.png",
            "book.png",
            "book.png",
            "book.png",
        };

        string lorem = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

        public MainPage()
        {
            InitializeComponent();
            viewlist.ItemsSource = GetMenuList();
            Detail = new NavigationPage(GetPage(0));
        }

        private List<MDPProperties> GetMenuList()
        {
            List<MDPProperties> list = new List<MDPProperties>();
            int ticks = 10;

            for (int tick = 0; tick < ticks; tick++)
            {
                list.Add(new MDPProperties()
                {
                    Text = ListNames[tick],
                    Detail = ListDetails[tick],
                    ImagePath = ListImages[tick],
                    TargetPage = GetPage(tick)
                });
            }

            return list;
        }

        private CarouselPage GetPage(int index)
        {
            CarouselPage carousel = new CarouselPage();
            carousel.Title = ListNames[index];

            for (int tick = 1; tick < 3 + 1; tick++)
            {
                Label lbl = new Label()
                {
                    Text = lorem,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    CharacterSpacing = 5,
                    TextColor = Color.Black,
                    Margin = 2
                };

                Label numberOfPage = new Label()
                {
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.Black,
                    Text = tick.ToString()
                };

                StackLayout labelStack = new StackLayout() 
                { 
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    BackgroundColor = Color.BlanchedAlmond,
                    Margin = 2
                };
                labelStack.Children.Add(lbl);
                Frame lblFrame = new Frame()
                {
                    Content = labelStack,
                    BorderColor = Color.Wheat,
                    CornerRadius = 10,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    BackgroundColor = Color.BlanchedAlmond,
                    Margin = 10
                };
                StackLayout numberOfPageStack = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.End
                };

                numberOfPageStack.Children.Add(numberOfPage);
                StackLayout stack = new StackLayout();
                stack.Children.Add(lblFrame);
                stack.Children.Add(numberOfPageStack);

                ContentPage page = new ContentPage();
                page.BackgroundColor = Color.RosyBrown;
                page.Content = stack;
                carousel.Children.Add(page);
            }

            return carousel;
        }

        private void viewlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MDPProperties selected = (MDPProperties)e.SelectedItem;
            CarouselPage page = selected.TargetPage;
            Detail = new NavigationPage(page);
        }
    }
}

using MauiBug_JitterScroll.Models;
using System.Reflection;
using System.Text.Json;

namespace MauiBug_JitterScroll
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();


            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MauiBug_JitterScroll.Models.calendar.json");
            var result = JsonSerializer.DeserializeAsync<List<CalendarItem>>(stream,
                new JsonSerializerOptions
                {
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString | System.Text.Json.Serialization.JsonNumberHandling.WriteAsString

                }
                ).Result;

            TournamentListView.ItemsSource = result;
        }

        
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FriendFolio.Pages
{
    public class IndexModel : PageModel
    {
        public string DailyQuestion { get; private set; } = string.Empty;

        public void OnGet()
        {
            string[] questions =
            [
                "Vilket litet ögonblick från den senaste tiden vill du minnas?",
        "Vilken låt påminner dig om någon du tycker om?",
        "Vad skulle du vilja tacka en vän för idag?",
        "Vilket minne får dig alltid att le?",
        "Vad borde någon skriva i din vänbok?"
            ];

            DailyQuestion = questions[DateTime.Today.DayOfYear % questions.Length];
        }
    }
}

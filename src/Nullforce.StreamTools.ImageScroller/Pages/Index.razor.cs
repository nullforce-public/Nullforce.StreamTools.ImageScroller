using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace Nullforce.StreamTools.ImageScroller.Pages
{
    public partial class Index : IAsyncDisposable
    {
        [Inject]
        public IOptions<ScrollSettings> optionsSettings { get; set; }

        private ScrollSettings settings;

        private string ListMaxHeightPx = "250px";
        private string MaxHeightPx = "200px";
        private string MaxWidthPx = "200px";
        private string MovementPx = "220px";

        private Timer timer;
        private string newImage;
        private List<string> images = new List<string>();

        private int index = 0;
        private List<string> fileNames = new List<string>();
        private string moveClass = "";

        protected override async Task OnInitializedAsync()
        {
            settings = optionsSettings.Value;

            // Set CSS values
            ListMaxHeightPx = $"{settings.ImageMaxHeight + 50}px";
            MaxHeightPx = $"{settings.ImageMaxHeight}px";
            MaxWidthPx = $"{settings.ImageMaxWidth}px";
            MovementPx = $"{settings.ImageMaxWidth + 20}px";

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!string.IsNullOrEmpty(settings.ImageLocation))
            {
                // Use the specified directory
                path = settings.ImageLocation;
            }

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                fileNames.Add($"images/{Path.GetFileName(file)}");
            }

            if (settings.ShuffleImages)
            {
                fileNames = ShuffleList(fileNames);
            }

            timer = new Timer(settings.IntervalInSeconds * 1_000);
            timer.Elapsed += Animate;
            timer.Enabled = true;
        }

        public async ValueTask DisposeAsync()
        {
            timer?.Dispose();
        }

        private void Animate(object sender, ElapsedEventArgs e)
        {
            int MaxImages = settings.ImageCount;

            InvokeAsync(async () =>
            {
                if (!string.IsNullOrEmpty(newImage))
                {
                    moveClass = "move-me";
                    images.Add(newImage);
                    newImage = "";
                    StateHasChanged();
                    await Task.Delay(950);
                }

                // Load an image and add it
                newImage = fileNames[index++];

                if (images.Count + 1 > MaxImages)
                {
                    images.RemoveAt(0);
                }

                // Reset the index
                if (index >= fileNames.Count)
                {
                    index = 0;
                }

                moveClass = "";

                StateHasChanged();
            });
        }

        private List<T> ShuffleList<T>(List<T> inputList)
        {
            Random r = new Random();
            List<T> shuffledList = new();

            while (inputList.Count > 0)
            {
                int index = r.Next(0, inputList.Count);
                shuffledList.Add(inputList[index]);
                inputList.RemoveAt(index);
            }

            return shuffledList;
        }
    }
}
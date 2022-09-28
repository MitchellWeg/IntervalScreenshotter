namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestSeconds()
        {
            IntervalScreenshotter.Screenshotter screenshotterInSeconds1 = new IntervalScreenshotter.Screenshotter(3, IntervalScreenshotter.Screenshotter.TypeOfSeconds.Seconds); 
            IntervalScreenshotter.Screenshotter screenshotterInSeconds2 = new IntervalScreenshotter.Screenshotter(10, IntervalScreenshotter.Screenshotter.TypeOfSeconds.Seconds); 
            IntervalScreenshotter.Screenshotter screenshotterInSeconds3 = new IntervalScreenshotter.Screenshotter(100, IntervalScreenshotter.Screenshotter.TypeOfSeconds.Seconds);

            Assert.Equal(3000, screenshotterInSeconds1.interval);
            Assert.Equal(10000, screenshotterInSeconds2.interval);
            Assert.Equal(100000, screenshotterInSeconds3.interval);
        }
    }
}
namespace Demo.MyJob
{
    public class MyJobAbpModule : JobCoreModule
    {
        public MyJobAbpModule()
        {
            Description = "Demo.MyJob Service";
            DisplayName = "Demo.MyJob";
            ServiceName = DisplayName;
        }
    }
}

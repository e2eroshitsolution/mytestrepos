namespace SpectrumApp;

public partial class Setup : ContentPage
{
    private List<Grid> collapsibleHeaders = new List<Grid>();
    private List<StackLayout> contentLayouts = new List<StackLayout>();
    private bool[] isCollapsed = { true, true, true, true, true, true };
    public Setup()
	{
		InitializeComponent();
        FindCollapsibleHeadersAndContentLayouts();
    }
    private void FindCollapsibleHeadersAndContentLayouts()
    {
        collapsibleHeaders.Add(CollapsibleHeader1);
        collapsibleHeaders.Add(CollapsibleHeader2);
        collapsibleHeaders.Add(CollapsibleHeader3);
        collapsibleHeaders.Add(CollapsibleHeader4);
        collapsibleHeaders.Add(CollapsibleHeader5);
        collapsibleHeaders.Add(CollapsibleHeader6);

        contentLayouts.Add(ContentLayout1);
        contentLayouts.Add(ContentLayout2);
        contentLayouts.Add(ContentLayout3);
        contentLayouts.Add(ContentLayout4);
        contentLayouts.Add(ContentLayout5);
        contentLayouts.Add(ContentLayout6);
    }
    public void OnFillCansButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FillColurants());
    }
    
    public void OnMaintenanceClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Maintenance());
    }
    private void OnSetUpButtonClicked(object sender, EventArgs e)
    {
       
        Navigation.PushAsync(new Setup());

    }
    public void onFileUploadClicked(object sender, EventArgs e)
    {
        // Navigate to the new page
        PickOptions options = new PickOptions()
        {
            PickerTitle = "Please select a file to upload"
        };
    }
    private void OnHeaderTapped(object sender, EventArgs e)
    {
        var label = (Label)sender;
        int headerIndex = Convert.ToInt32(label.AutomationId); // Get the index from the AutomationId

        if (isCollapsed[headerIndex])
        {
            ExpandHeader(headerIndex);
        }
        else
        {
            CollapseHeader(headerIndex);
        }

        isCollapsed[headerIndex] = !isCollapsed[headerIndex];
    }

    private void CollapseHeader(int index)
    {
        collapsibleHeaders[index].HeightRequest = 50; // Adjust the collapsed height
        contentLayouts[index].IsVisible = false;
    }

    private void ExpandHeader(int index)
    {
        collapsibleHeaders[index].HeightRequest = 50; // Adjust the expanded height
        contentLayouts[index].IsVisible = true;
    }
}
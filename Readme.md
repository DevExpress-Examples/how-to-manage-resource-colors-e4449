<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to manage resource colors


<p>This example illustrates how to manage resource colors in the scheduling application. Generally, you are using bound mode and binding the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerResource_Colortopic"><u>Resource.Color Property</u></a> to the specific field of an integer type. It is a ModelResource.Color in this example. Note that the format in which the color is stored is specified via the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerColorSavingTypeEnumtopic"><u>ColorSavingType</u></a> option. We use the <strong>"ArgbColor"</strong> format. The following logic is applied to convert the <strong>Color </strong>object to this format:<br />
</p>

```cs
int result = BitConverter.ToInt32(new byte[] { color.B, color.G, color.R, color.A }, 0);

```

<p>The opposite conversion is accomplished as follows:<br />
</p>

```cs
string hexString = "#" + ((int)value).ToString("X");
Color color = (Color)ColorConverter.ConvertFromString(hexString);

```

<p>This logic is encapsulated in the <strong>CustomColorConverter </strong>class. Its instance is assigned to the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfEditorsBaseEdit_EditValueConvertertopic"><u>BaseEdit.EditValueConverter Property</u></a> of the <a href="http://documentation.devexpress.com/#WPF/clsDevExpressXpfEditorsColorEdittopic"><u>ColorEdit Class</u></a> which is used to select a color for the newly added resource.</p><p>Note that the similar technique is used in the <a href="https://www.devexpress.com/Support/Center/p/E3496">How to bind SchedulerControl to ObservableCollection</a> code example.</p><p>Here is a screenshot that illustrates a sample application in action:</p><p><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-manage-resource-colors-e4449/12.1.9+/media/243e893b-fd6d-45db-92c7-9b681e2c1688.png"></p><p><strong>See Also:</strong><br />
<a href="http://documentation.devexpress.com/#WPF/CustomDocument8710"><u>Resources</u></a></p>

<br/>



# How to change the True and False value in GridCheckBoxFilter for GridCheckBoxColumn in WPF DataGrid(SfDataGrid)?

## About the sample
This example illustrates how to change the True and False value in GridCheckBoxFilter for GridCheckBoxColumn in [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid)?

[WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid) does not contain support for the change the resource key translates for True and False string in GridFilterControl. You can change this string by customizing the CheckBoxFilterControl.ItemTemplate.

```XML
<syncfusion:GridCheckBoxColumn.FilterPopupStyle>
                        <Style TargetType="syncfusion:GridFilterControl">
                            <Setter Property="CheckboxFilterStyle">
                                <Setter.Value>
                                    <Style TargetType="syncfusion:CheckboxFilterControl">
                                        <Setter Property="Background" Value="Red"/>
                                        <Setter Property="ItemTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <CheckBox Margin="4"
            HorizontalAlignment="Stretch"
            HorizontalContentAlignment="Stretch"
            Focusable="False"
            Content="{Binding Converter={StaticResource boolConverter}}"          
            FontWeight="{Binding FontWeight,RelativeSource={RelativeSource Self}}"
            Foreground="{Binding Foreground,RelativeSource={RelativeSource Self}}"
            IsChecked="{Binding IsSelected,
                                Mode=TwoWay}">
                                                    </CheckBox>
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </Setter.Value>
                            </Setter>
                        </Style>
</syncfusion:GridCheckBoxColumn.FilterPopupStyle>
```


```C#
public class BoolConverter : IValueConverter
{
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as FilterElement).DisplayText == "True")
                return "Yes";
            else
                return "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
}
```

## Requirements to run the demo
Visual Studio 2015 and above versions

# Extended WPF TabControl for C# .NET Framework
A demonstration of how to extend a TabControl with an extra WPF element.

![image](https://github.com/ObstetrixBear/wpf-framework-extend-tab-control/assets/129376193/750e6373-9ffd-4c01-8ca8-f29bbc473e6b)

## What this is
At work, I had a tab-control. In it, I needed to display a message between the Tab Header field and the Content. This is my solution.

## Implementation

Surprisingly enough, implementing the `SettingsAwareTabControl` requires very little code. All you need to do to is derive from `TabControl` and then do two things: register the dependency property for the settings bar using a `DependencyProperty`, and then wrap that `SettingsControlProperty` in getters and setters. 

## Usage 

To use this control, define the control template as a style under the `<[Element].Resources>` tag.

```XAML
<Style TargetType="{x:Type local:SettingsAwareTabControl}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type local:SettingsAwareTabControl}">
                <Grid>
                    <!-- Here, we specify how tall the various fields should be. -->
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <!-- Tab headers -->
                        <RowDefinition Height="Auto"/>
                        <!-- Settings -->
                        <RowDefinition Height="*"/>
                        <!-- Tab content -->
                    </Grid.RowDefinitions>
                    <TabPanel Grid.Row="0" IsItemsHost="True" />
                    <Border Grid.Row="1" Background="Gray" Height="2" />
                    <!-- This is the visible bar -->
                    <ContentControl Grid.Row="1" Content="{Binding SettingsControl, RelativeSource={RelativeSource TemplatedParent}}" />
                    <!-- This is the content -->
                    <ContentPresenter Grid.Row="2" Content="{Binding SelectedContent, RelativeSource={RelativeSource TemplatedParent}}" />
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

Then, place the tag itself like you would any other custom WPF Element in the XAML body. Be aware that you'll need to define the content of the SettingsControl from within the SettingsAwareTabControl, like so:

```XAML
<local:SettingsAwareTabControl>
    <local:SettingsAwareTabControl.SettingsControl>
        <!-- This is where you define the content of the settings bar -->
        <StackPanel Background="LightGray" Height="50">
            <TextBlock Text="Extra Content Here" HorizontalAlignment="Center" VerticalAlignment="Center" />
        </StackPanel>
    </local:SettingsAwareTabControl.SettingsControl>

    <!-- The tabs go here -->
    <TabItem Header="Tab 1">
        <Label>One!</Label>
    </TabItem>
    <TabItem Header="Tab 2">
        <Label>Two!</Label>
    </TabItem>
</local:SettingsAwareTabControl>
```


## In closing
I'm not used to data-binding and Windows style programming. In fact, I'm pretty sure this code would be blindingly obvious to any seasoned WPF veteran. But since extending classes (in what I suppose must be called the Microsoft idiom) appears to be how WPF is meant to work, and it was nonobvious to me, I thought it could be helpful to put this code online in case someone had the same issue I had, or in case I needed to repeat it at a later date. 

Have a look if you like, and if you should find something wrong or an aspect that could be improved, please let me know. 

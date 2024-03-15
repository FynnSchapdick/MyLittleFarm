using System;
using System.Collections.Generic;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.VisualElements;
using SkiaSharp;

namespace MyFarmApp.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly Random _random = new();

    public MainWindowViewModel()
    {
        int sectionsOuter = 130;
        int sectionsWidth = 20;
        
        SKColor red = SKColor.Parse("#FF0000");
        SKColor green = SKColor.Parse("#00FF00");
        SKColor orange = SKColor.Parse("#FFA500");

        Needle = new NeedleVisual
        {
            Value = 21,
            ScalesYAt = 6,
            ScalesXAt = 6
            
        };

        Series = GaugeGenerator.BuildAngularGaugeSections(
            new GaugeItem(14, s => SetStyle(sectionsOuter, sectionsWidth, red, s)),
            new GaugeItem(3, s => SetStyle(sectionsOuter, sectionsWidth, orange, s)),
            new GaugeItem(8, s => SetStyle(sectionsOuter, sectionsWidth, green, s)),
            new GaugeItem(3, s => SetStyle(sectionsOuter, sectionsWidth, orange, s)),
            new GaugeItem(14, s => SetStyle(sectionsOuter, sectionsWidth, red, s)));

        VisualElements = new VisualElement<SkiaSharpDrawingContext>[]
        {
            new AngularTicksVisual
            {
                LabelsSize = 16,
                LabelsOuterOffset = 15,
                OuterOffset = 65,
                TicksLength = 20
            },
            Needle
        };
    }

    public IEnumerable<ISeries> Series { get; set; }

    public IEnumerable<VisualElement<SkiaSharpDrawingContext>> VisualElements { get; set; }

    public NeedleVisual Needle { get; set; }

    private static void SetStyle(double sectionsOuter, double sectionsWidth, SKColor color, PieSeries<ObservableValue> series)
    {
        series.OuterRadiusOffset = sectionsOuter;
        series.MaxRadialColumnWidth = sectionsWidth;
        series.Fill = new SolidColorPaint(color);
    }
}
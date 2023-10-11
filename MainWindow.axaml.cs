using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;

namespace AvaloniaApp1;

public partial class MainWindow : Window
{
    private List<string> MyItems = new List<string>();
    public MainWindow()
    {
        InitializeComponent();
    }

    private BigInteger fact(int n)
    {
        BigInteger result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    private void PeresGetResultBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (PeresInput.Text.Trim(' ') == "0")
            {
                PeresResult.Text = "1";
                
            } else if (int.Parse(PeresInput.Text) < 0)
            {
                PeresResult.Text = "Только положительные числа";
            }
            else
            {
                PeresResult.Text = fact(int.Parse(PeresInput.Text)).ToString();
            }
        }
        catch
        {
            PeresResult.Text = "нет";
        }
    }

    private void PeresGetVariants_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (PeresInput3.Text != null && PeresInput3.Text.All(char.IsDigit) && PeresInput3.Text != "")
            {
                PeresResult2.Text = String.Join(" ", GeneratePermutations(int.Parse(PeresInput3.Text), PeresInput2.Text.ToCharArray()));
                PeresResult3.Text = String.Join(" ", GeneratePermutations(int.Parse(PeresInput3.Text), PeresInput2.Text.ToCharArray()).ToHashSet());
            }
            else
            {
                PeresResult2.Text = String.Join(" ", GeneratePermutations(PeresInput2.Text.Length, PeresInput2.Text.ToCharArray()));
                PeresResult3.Text = String.Join(" ", GeneratePermutations(PeresInput2.Text.Length, PeresInput2.Text.ToCharArray()).ToHashSet());
            }
            
        }
        catch
        {
            Console.WriteLine("Wrong data");
        }
    }
    
    static List<string> GeneratePermutations(int length, char[] symbols)
    {
        List<string> permutations = new List<string>();
        char[] currentPermutation = new char[length];

        GeneratePermutationsRecursively(permutations, symbols, currentPermutation, length, 0);

        return permutations;
    }
    
    static void GeneratePermutationsRecursively(List<string> permutations, char[] operators, char[] currentPermutation, int length, int index)
    {
        if (index == length)
        {
            permutations.Add(new string(currentPermutation));
            return;
        }

        foreach (char op in operators)
        {
            currentPermutation[index] = op;
            GeneratePermutationsRecursively(permutations, operators, currentPermutation, length, index + 1);
        }
    }

    private void RazmGetResult_OnClick(object? sender, RoutedEventArgs e)
    {
        if (RazmTopIndex.Text != null && RazmTopIndex.Text.All(char.IsDigit) && RazmTopIndex.Text != "" &&
            RazmBottomIndex.Text != null && RazmBottomIndex.Text.All(char.IsDigit) && RazmBottomIndex.Text != "" &&
            int.Parse(RazmBottomIndex.Text) >= int.Parse(RazmTopIndex.Text))
        {
            RazmResult.Text =
                (fact(int.Parse(RazmBottomIndex.Text)) / 
                 fact(int.Parse(RazmBottomIndex.Text) - int.Parse(RazmTopIndex.Text))).ToString();
        }
        else
        {
            RazmResult.Text = "нет";
        }
    }

    private void SochGetResult_OnClick(object? sender, RoutedEventArgs e)
    {
        if (SochTopIndex.Text != null && SochTopIndex.Text.All(char.IsDigit) && SochTopIndex.Text != "" &&
            SochBottomIndex.Text != null && SochBottomIndex.Text.All(char.IsDigit) && SochBottomIndex.Text != "" &&
            int.Parse(SochBottomIndex.Text) >= int.Parse(SochTopIndex.Text))
        {
            SochResult.Text =
                (fact(int.Parse(SochBottomIndex.Text)) / 
                 (fact(int.Parse(SochBottomIndex.Text) - int.Parse(SochTopIndex.Text)) * fact(int.Parse(SochTopIndex.Text)))).ToString();
        }
        else
        {
            SochResult.Text = "нет";
        }
    }
}
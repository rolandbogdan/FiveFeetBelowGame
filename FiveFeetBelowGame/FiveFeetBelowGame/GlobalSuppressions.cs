// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Rock")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Rock")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Array is necessary.", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.Player.Inventory")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "No, it shouldnt.", Scope = "member", Target = "~F:FiveFeetBelowGame.VM.GameItem.area")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Unnecessary", Scope = "member", Target = "~F:FiveFeetBelowGame.VM.GameItem.area")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Rocks")]

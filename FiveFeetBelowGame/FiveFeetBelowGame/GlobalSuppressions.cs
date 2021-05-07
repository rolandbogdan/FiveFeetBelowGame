﻿// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Rock")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Rock")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Array is necessary.", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.Player.Inventory")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "No, it shouldnt.", Scope = "member", Target = "~F:FiveFeetBelowGame.VM.GameItem.area")]
[assembly: SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Unnecessary", Scope = "member", Target = "~F:FiveFeetBelowGame.VM.GameItem.area")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Blocks")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.InitModel(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.InitModel(System.String)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.InitModel(System.String)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.InitModel(System.String)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.Blocks")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.TextToItemConverter(System.Char)~FiveFeetBelowGame.VM.GameItem")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.LevelGenerator.RowGenerator~System.String")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.Move(System.Int32,System.Int32)")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:Use built-in type alias", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameToLvl.SaveToLvl(System.String)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameToLvl.SaveToLvl(System.String)")]
[assembly: SuppressMessage("Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameToLvl.SaveToLvl(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameToLvl.SaveToLvl(System.String)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameToLvl.SaveToLvl(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameToLvl.OreSelector(FiveFeetBelowGame.VM.OneOre)~System.Char")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.LevelGenerator.GenerateSectionJson(FiveFeetBelowGame.VM.GameItem[,])~FiveFeetBelowGame.VM.GameItem[,]")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.LevelGenerator.GenerateFirstSectionJson~FiveFeetBelowGame.VM.GameItem[,]")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.GetRenderedBlocks~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.PlayerNeighborBlocks")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.#ctor(System.String)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.SaveMap(FiveFeetBelowGame.IGameObject[,],System.String)")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.UI.Renderer.GetText~System.Windows.Media.Drawing")]
[assembly: SuppressMessage("Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.#ctor(System.String)")]
[assembly: SuppressMessage("Globalization", "CA1310:Specify StringComparison for correctness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.SaveMap(FiveFeetBelowGame.IGameObject[,],System.String)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.SaveMap(FiveFeetBelowGame.IGameObject[,],System.String)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.AddMonsters(FiveFeetBelowGame.IGameObject[,]@)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.GenerateFirstSection~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.LoadMap(System.String)~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.RowGenerator(FiveFeetBelowGame.IGameObject[,]@,System.Int32)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.RenderedBlocks")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.RenderedBlocks")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.AddMonsters(FiveFeetBelowGame.IGameObject[,]@)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.LoadMap(System.String)~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.SaveMap(FiveFeetBelowGame.IGameObject[,],System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.UI.Renderer.AirBrush")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Unnecessary", Scope = "member", Target = "~P:FiveFeetBelowGame.VM.GameModel.PlayerNeighborBlocks")]
[assembly: SuppressMessage("Security", "CA2326:Do not use TypeNameHandling values other than None", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.#ctor(System.String)")]
[assembly: SuppressMessage("Security", "CA2326:Do not use TypeNameHandling values other than None", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.LoadMap(System.String)~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.AddMonsters(FiveFeetBelowGame.IGameObject[,]@)")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.RowGenerator(FiveFeetBelowGame.IGameObject[,]@,System.Int32)")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.OneBlock.PropertySetter")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:Arithmetic expressions should declare precedence", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.OneMonster.#ctor(System.Double,System.Double)")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "Unnecessary", Scope = "member", Target = "~M:FiveFeetBelowGame.BL.GameLogic.GetRenderedBlocks(System.Int32,System.Int32)~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "<Pending>", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.GenerateNewSection~FiveFeetBelowGame.IGameObject[,]")]
[assembly: SuppressMessage("Security", "CA2326:Do not use TypeNameHandling values other than None", Justification = "<Pending>", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.LoadMap(System.String)")]
[assembly: SuppressMessage("Security", "CA2326:Do not use TypeNameHandling values other than None", Justification = "<Pending>", Scope = "member", Target = "~M:FiveFeetBelowGame.JsonHandler.SaveMap(FiveFeetBelowGame.IGameObject[,],System.String)")]

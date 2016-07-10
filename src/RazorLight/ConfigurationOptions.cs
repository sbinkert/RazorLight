﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;

namespace RazorLight
{
	public class ConfigurationOptions
    {
		/// <summary>
		/// Absolute path to the root folder which contains Razor views
		/// </summary>
		private string viewsFolder;
		public string ViewsFolder
		{
			get
			{
				return viewsFolder;
			}
			set
			{
				if (value == null || !Directory.Exists(value))
				{
					throw new DirectoryNotFoundException();
				}

				viewsFolder = value;
			}
		}

		/// <summary>
		/// If set to true - all dependencies from the entry assembly will be added as a compiler metatada references while compiling Razor views
		/// </summary>
		public bool LoadDependenciesFromEntryAssembly { get; set; } = true;

		/// <summary>
		/// Additional compilation metadata referenes
		/// </summary>
		public IList<MetadataReference> AdditionalCompilationReferences { get; } = new List<MetadataReference>();

		public static ConfigurationOptions Default => new ConfigurationOptions();
    }
}

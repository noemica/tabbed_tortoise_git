﻿using Common;
using log4net;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TabbedTortoiseGit
{
    static class TTG
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TTG ) );

        private static readonly String RUN_ON_STARTUP_KEY_PATH = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private static readonly String RUN_ON_STARTUP_KEY_NAME = "Tabbed TortoiseGit";

        public static String GetExe()
        {
            return Process.GetCurrentProcess().MainModule?.FileName ?? throw new InvalidOperationException( "Cannot find Tabbed TortoiseGit EXE." );
        }

        private static String GetStartupKeyValue()
        {
            return $"\"{GetExe()}\" --startup";
        }

        public static bool RunOnStartup
        {
            get
            {
                try
                {
                    using RegistryKey? run = Registry.CurrentUser.OpenSubKey( RUN_ON_STARTUP_KEY_PATH, false );
                    var value = run?.GetValue( RUN_ON_STARTUP_KEY_NAME ) as String;
                    return value == GetStartupKeyValue();
                }
                catch( Exception e )
                {
                    LOG.Error( "An error occurred getting the current state of the 'Run on Startup' registry item.", e );
                }
                return false;
            }

            set
            {
                try
                {
                    using RegistryKey? run = Registry.CurrentUser.OpenSubKey( RUN_ON_STARTUP_KEY_PATH, true );
                    if( value )
                    {
                        run?.SetValue( RUN_ON_STARTUP_KEY_NAME, GetStartupKeyValue() );
                    }
                    else
                    {
                        if( run?.GetValue( RUN_ON_STARTUP_KEY_NAME ) != null )
                        {
                            run.DeleteValue( RUN_ON_STARTUP_KEY_NAME );
                        }
                    }
                }
                catch( Exception e )
                {
                    LOG.Error( "An error occurred setting the current state of the 'Run on Startup' registry item.", e );
                }
            }
        }

        public static async Task<Version?> IsUpToDate()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create( "https://raw.githubusercontent.com/anickle060193/tabbed_tortoise_git/master/TabbedTortoiseGit/TabbedTortoiseGit.csproj" );
                request.ContentType = "text/plain";
                request.Method = "GET";
                AssemblyName a = Assembly.GetExecutingAssembly().GetName();
                Version currentVersion = a.Version ?? new Version();
                request.UserAgent = $"{a.Name} {currentVersion}";

                using WebResponse response = await request.GetResponseAsync();
                using StreamReader reader = new StreamReader( response.GetResponseStream() );
                String responseText = reader.ReadToEnd();

                var versionText = XElement.Parse( responseText )
                    ?.Element( "PropertyGroup" )
                    ?.Element( "Version" )
                    ?.Value;
                if( versionText == null )
                {
                    return null;
                }

                var newestVersion = Version.Parse( versionText );

                if( newestVersion != null
                 && newestVersion > currentVersion )
                {
                    return newestVersion;
                }
                else
                {
                    return null;
                }
            }
            catch( Exception e )
            {
                LOG.Error( "An error occured while trying to check if application is up to date.", e );
            }

            return null;
        }

        public static async Task<bool> UpdateApplication( Version newestVersion )
        {
            try
            {
                String updateUrl = $"https://github.com/anickle060193/tabbed_tortoise_git/raw/{newestVersion.ToString( 3 )}/Setup/Output/Setup.msi";
                String path = Path.GetTempPath();
                String downloadLocation = Path.Combine( path, $"tabbed_tortoisegit_setup-{newestVersion.ToString( 3 )}.msi" );

                using WebClient client = new WebClient();
                await client.DownloadFileTaskAsync( updateUrl, downloadLocation );

                Process.Start( downloadLocation );

                return true;
            }
            catch( Exception e )
            {
                LOG.Error( "An error has occurred while updating the application.", e );
            }

            return false;
        }

        public static bool VerifyAssemblyVersions()
        {
            Version? ttgVersion = Assembly.GetAssembly( typeof( TabbedTortoiseGit.TTG ) )?.GetName().Version;
            Version? tabsVersion = Assembly.GetAssembly( typeof( Tabs.TabControl ) )?.GetName().Version;
            Version? commonVersion = Assembly.GetAssembly( typeof( Common.Util ) )?.GetName().Version;

            if( ttgVersion != null
             && ttgVersion == tabsVersion
             && ttgVersion == commonVersion )
            {
                return true;
            }

            String? ttg = ttgVersion?.ToString( 3 );
            String? tabs = tabsVersion?.ToString( 3 );
            String? common = commonVersion?.ToString( 3 );
            LOG.Fatal( $"Assembly version mismatch - TTG: {ttg} - Tabs: {tabs} - Common: {common}" );

            String versionMismatchMessage = ( $"The current assembly versions do not match:\n" +
                                                $"    Tabbed TortoiseGit: {ttg}\n" +
                                                $"    Tabs: {tabs}\n" +
                                                $"    Common: {common}\n\n" +
                                                $"Update Tagged TortoiseGit to resolve issue.\n" +
                                                $"If issue persists, uninstall and re-install Tabbed TortoiseGit." );
            MessageBox.Show( versionMismatchMessage, "Assembly Version Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return false;
        }
    }
}

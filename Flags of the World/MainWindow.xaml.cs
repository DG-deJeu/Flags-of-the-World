using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Flags_of_the_World
{
    public partial class MainWindow : Window
    {
        string Path = @"D:\C#\Projects\Flags of the World\Flags of the World\Flags of the World\Resources\";
        public static int MCAnswer;
        public static string TOAnswer;
        public static string ActiveFlag;
        public static string ActiveMode;
        public static int Counter = 0;
        public static int WrongAnswers;
        public static int RightAnswers;
        public static bool HasHitEnter = false;
        public static string PlayOrView;
        public static int VFPage = 1;
        public static string[] _ActivePack = { "Error" };
        List<string> UsedFlags = new List<string>();

        //Packs
        #region Packs
        string[] AfricaPack =
        {
            "Algeria", "Angola", "Benin", "Botswana", "British Indian Ocean Territory", "Burkina Faso", "Burundi", "Cameroon", "Cape Verde", "Central African Republic", "Chad", "Comoros", "Republic of the Congo", "DR Congo", "Côte d'Ivoire", "Djibouti", "Egypt", "Equatorial Guinea", "Eritrea", "Eswatini", "Ethiopia", "Gabon", "Gambia", "Ghana", "Guinea", "Guinea-Bissau", "Kenya", "Lesotho", "Liberia", "Libya", "Madagascar", "Malawi", "Mali", "Mauritania", "Mauritius", "Mayotte", "Morocco", "Mozambique", "Namibia", "Niger", "Nigeria", "Réunion", "Rwanda", "Saint Helena, Ascension and Tristan da Cunha", "São Tomé and Príncipe", "Senegal", "Seychelles", "Sierra Leone", "Somalia", "South Africa", "South Sudan", "Sudan", "Tanzania", "Togo", "Tunisia", "Uganda", "Western Sahara", "Zambia", "Zimbabwe"
        };

        string[] AsiaPack =
{
            "Afghanistan", "Armenia", "Azerbaijan", "Bahrain", "Bangladesh", "Bhutan", "Brunei", "Cambodia", "China", "Egypt", "Georgia", "Hong Kong","India", "Indonesia", "Iran", "Iraq", "Isreal", "Japan", "Jordan", "Kazakhstan", "North Korea", "South Korea", "Kuwait", "Kyrgyzstan", "Laos", "Lebanon", "Macau", "Malaysia", "Maldives", "Mongolia", "Myanmar", "Nepal", "Oman", "Pakistan", "Palestine", "Philippines", "Qatar", "Russia", "Saudi Arabia", "Singapore", "Sri Lanka", "Syria", "Taiwan", "Tajikistan", "Thailand", "Timor-Leste", "Turkey", "Turkmenistan", "United Arab Emirates", "Uzbekistan", "Vietnam", "Yemen"
        };

        string[] EuropePack =
        {
            "Åland Islands", "Albania", "Andorra", "Austria", "Belarus", "Belgium", "Bosnia and Herzegovina", "Bulgaria", "Croatia", "Cyprus", "Czechia","Denmark", "Estonia", "Faroe Islands", "Finland", "France", "Germany", "Gibraltar", "Greece", "Guernsey", "Hungary", "Iceland", "Ireland","Isle of Man", "Italy", "Jersey", "Kosovo", "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Malta", "Moldova", "Monaco", "Montenegro", "Netherlands", "North Macedonia", "Norway", "Poland", "Portugal", "Romania", "Russia", "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain", "Svalbard and Jan Mayen", "Sweden", "Switzerland", "Turkey", "Ukraine", "United Kingdom", "Vatican City"
        };

        string[] NorthAmericaPack =
        {
            "Anguilla", "Antiqua and Barbuda", "Aruba", "Bahamas", "Barbados", "Belize", "Bermuda", "Canada", "Caribbean Netherlands", "Cayman Islands", "Costa Rica", "Cuba", "Curaçao", "Dominica", "Dominican Republic", "El Salvador", "Greenland", "Grenada", "Guadeloupe", "Guatemala", "Haiti", "Honduras", "Jamaica", "Martinique", "Mexico", "Montserrat", "Nicaragua", "Panama", "Puerto Rico", "Saint Barthélemy", "Saint Kitts and Nevis", "Saint Lucia", "Saint Martin", "Saint Pierre and Miquelon", "Saint Vincent and the Grenadines", "Sint Maarten", "Turks and Caicos Islands", "United States", "United States Minor Outlying Islands", "British Virgin Islands", "United States Virgin Islands"
        };

        string[] OceaniaPack =
        {
            "American Samoa", "Australia", "Christmas Island", "Cocos Islands", "Cook Islands", "Fiji", "French Polynesia", "Guam", "Indonesia", "Kiribati", "Marshall Islands", "Micronesia", "Nauru", "New Caledonia", "New Zealand", "Niue", "Norfolk Island", "Northern Mariana Islands", "Palau", "Papua New Guinea", "Pitcairn Islands", "Samoa", "Solomon Islands", "Tokelau", "Tonga", "Tuvalu", "Vanuatu", "Wallis and Futuna"
        };

        string[] SouthAmericaPack =
        {
            "Argentina", "Bolivia", "Brazil", "Chile", "Colombia", "Ecuador", "Falkland Islands", "French Guiana", "Guyana", "Paraguay", "Peru", "Suriname", "Trinidad and Tobago", "Uruguay", "Venezuela"
        };

        string[] WorldPack =
        {
             "Afghanistan", "Åland Islands", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antiqua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Caribbean Netherlands", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos Islands", "Colombia", "Comoros", "Republic of the Congo", "DR Congo", "Cook Islands", "Costa Rica", "Côte d'Ivoire", "Croatia", "Cuba", "Curaçao", "Cyprus", "Czechia", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "England", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern and Antarctic Lands", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard Island and McDonald Islands", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Isreal", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "North Korea", "South Korea", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "North Macedonia", "Northern Ireland", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn Islands", "Poland", "Portugal", "Puerto Rico", "Qatar", "Réunion", "Romania", "Russia", "Rwanda", "Saint Barthélemy", "Saint Helena, Ascension and Tristan da Cunha", "Saint Kitts and Nevis", "Saint Lucia", "Saint Martin", "Saint Pierre and Miquelon", "Saint Vincent and the Grenadines", "Samoa", "San marino", "São Tomé and Príncipe", "Saudi Arabia", "Scotland", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Sint Maarten", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "United States Minor Outlying Islands", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "British Virgin Islands", "United States Virgin Islands", "Wales", "Wallis and Futuna", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"
        };

        string[] USStatesPack =
        {
            "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois","Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia","Washington", "West Virginia", "Wisconsin", "Wyoming"
        };

        string[] OrganizationsPack =
        {
            "United Nations", "European Union", "NATO", "Commonwealth of Nations", "Organization of American States", "Union of South American Nations","African Union", "Southern African Development Community", "East African Community", "Gulf Cooperation Council", "Nordic Council","Association of Southeast Asian Nations", "Collective Security Treaty Organization", "Commonwealth of Independant States","Eurasian Economic Union", "Turkic Council", "Pacific Community", "Caribbean Community", "Central American Integration System", "Organisation internationale de la Francophonie", "Arab League", "Organisation of Islamic Cooperation", "OPEC"
        };
        #endregion

        //MainMenu
        #region MainMenu
        private void MM_PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayOrView = "Play";
            MainMenu.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
        }

        private void MM_ViewFlagsButton_Click(object sender, RoutedEventArgs e)
        {
            PlayOrView = "View";
            MainMenu.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
        }

        private void MM_QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion MainMenu

        //FlagPackMenu Page1
        #region FlagPackMenuPG1
        
        private void FPM_Back_Click(object sender, RoutedEventArgs e)
        {
            FlagPackMenu_Page1.Visibility = Visibility.Hidden;
            MainMenu.Visibility = Visibility.Visible;
        }

        private void FPM_NextPage_Click(object sender, RoutedEventArgs e)
        {
            FlagPackMenu_Page1.Visibility = Visibility.Hidden;
            FlagPackMenu_Page2.Visibility = Visibility.Visible;
        }

        private void FPM_Europe_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = EuropePack;
            PlayOrViewMethod();
        }

        private void FPM_Asia_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = AsiaPack;
            PlayOrViewMethod();
        }

        private void FPM_World_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = WorldPack;
            PlayOrViewMethod();
        }

        private void FPM_Africa_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = AfricaPack;
            PlayOrViewMethod();
        }

        private void FPM_SouthAmerica_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = SouthAmericaPack;
            PlayOrViewMethod();
        }

        private void FPM_NorthAmerica_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = NorthAmericaPack;
            PlayOrViewMethod();
        }

        #endregion

        //FlagPackMenu Page2
        #region FlagPackMenuPG2
        private void FPM2_PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            FlagPackMenu_Page2.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
        }

        private void FPM2_Back_Click(object sender, RoutedEventArgs e)
        {
            FlagPackMenu_Page2.Visibility = Visibility.Hidden;
            MainMenu.Visibility = Visibility.Visible;
        }

        private void FPM2_Oceania_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = OceaniaPack;
            PlayOrViewMethod();
        }

        private void FPM2_USStates_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = USStatesPack;
            PlayOrViewMethod();
        }

        private void FPM2_Organizations_Click(object sender, RoutedEventArgs e)
        {
            _ActivePack = OrganizationsPack;
            PlayOrViewMethod();
        }
        #endregion

        //Play MultipleChoice
        #region PlayMultipleChoice
        public void StartPlayingMC()
        {
            PFMC_PackLabel.Content = _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "World";
            PFMC_AnswerA_Button.Width = 450;
            PFMC_AnswerB_Button.Width = 450;
            PFMC_AnswerC_Button.Width = 450;
            PFMC_AnswerD_Button.Width = 450;

            if (Counter < _ActivePack.Length)
            {
                PFMC_Counter.Content = string.Format("{0}/{1}", Counter + 1, _ActivePack.Length);

                List<string> ActiveFlags = new List<string>();
                Random random = new Random();

                while (ActiveFlags.Count < 4)
                {
                    int PickRandomFromPack = random.Next(_ActivePack.Length);
                    string RandomPicked = _ActivePack[PickRandomFromPack];

                    if (ActiveFlags.Contains(RandomPicked))
                    {

                    }
                    else
                    {
                        ActiveFlags.Add(RandomPicked);
                    }
                }

                int NoDoubleCounter = 0;

                do
                {
                    if (NoDoubleCounter < 4)
                    {
                        int RandomIndexAF = random.Next(4);
                        ActiveFlag = ActiveFlags[RandomIndexAF];
                        MCAnswer = RandomIndexAF;
                        NoDoubleCounter++;
                    }
                    else
                    {
                        ActiveFlags.Clear();
                        while (ActiveFlags.Count < 4)
                        {
                            int PickRandomFromPack = random.Next(_ActivePack.Length);
                            string RandomPicked = _ActivePack[PickRandomFromPack];

                            if (ActiveFlags.Contains(RandomPicked))
                            {

                            }
                            else
                            {
                                ActiveFlags.Add(RandomPicked);
                                NoDoubleCounter = 0;
                            }
                        }
                    }
                } while (UsedFlags.Contains(ActiveFlag));

                UsedFlags.Add(ActiveFlag);
                PFMC_Flag.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", ActiveFlag), UriKind.Absolute));
                PFMC_AnswerA_Button.Content = "     " + ActiveFlags[0];
                PFMC_AnswerB_Button.Content = "     " + ActiveFlags[1];
                PFMC_AnswerC_Button.Content = "     " + ActiveFlags[2];
                PFMC_AnswerD_Button.Content = "     " + ActiveFlags[3];

                if (ActiveFlags[0].Length > 21)
                {
                    PFMC_AnswerA_Button.Width = double.NaN;
                }
                if (ActiveFlags[1].Length > 21)
                {
                    PFMC_AnswerB_Button.Width = double.NaN;
                }
                if (ActiveFlags[2].Length > 21)
                {
                    PFMC_AnswerC_Button.Width = double.NaN;
                }
                if (ActiveFlags[3].Length > 21)
                {
                    PFMC_AnswerD_Button.Width = double.NaN;
                }
                PlayingField_MultipleChoice.Visibility = Visibility.Visible;
            }

            //End
            else
            {
                EndPF();
            }

        }
        #endregion

        //PlayingField_MultipleChoice
        #region PFMC
        
        public void PFMCRightAnswer()
        {
            PFMC__QuestionLabel.Visibility = Visibility.Hidden;
            PFMC__RightAnswerLabel.Visibility = Visibility.Visible;
            PFMC_NextQuestion_Button.Visibility = Visibility.Visible;

            RightAnswers++;
        }

        public void PFMCWrongAnswer()
        {
            PFMC__QuestionLabel.Visibility = Visibility.Hidden;
            PFMC__WrongAnswerLabel.Visibility = Visibility.Visible;
            PFMC__AnswerLabel.Visibility = Visibility.Visible;
            PFMC__AnswerLabel.Content = ActiveFlag;
            PFMC_NextQuestion_Button.Visibility = Visibility.Visible;

            WrongAnswers++;
        }

        private void PFMC_AnswerA_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 0)
            {
                PFMCRightAnswer();
            }
            else
            {
                PFMCWrongAnswer();
            }

            PFMC_AnswerA_Button.IsEnabled = false;
            PFMC_AnswerB_Button.IsEnabled = false;
            PFMC_AnswerC_Button.IsEnabled = false;
            PFMC_AnswerD_Button.IsEnabled = false;
        }

        private void PFMC_AnswerB_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 1)
            {
                PFMCRightAnswer();
            }
            else
            {
                PFMCWrongAnswer();
            }

            PFMC_AnswerA_Button.IsEnabled = false;
            PFMC_AnswerB_Button.IsEnabled = false;
            PFMC_AnswerC_Button.IsEnabled = false;
            PFMC_AnswerD_Button.IsEnabled = false;
        }

        private void PFMC_AnswerC_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 2)
            {
                PFMCRightAnswer();
            }
            else
            {
                PFMCWrongAnswer();
            }

            PFMC_AnswerA_Button.IsEnabled = false;
            PFMC_AnswerB_Button.IsEnabled = false;
            PFMC_AnswerC_Button.IsEnabled = false;
            PFMC_AnswerD_Button.IsEnabled = false;
        }

        private void PFMC_AnswerD_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 3)
            {
                PFMCRightAnswer();
            }
            else
            {
                 PFMCWrongAnswer();
            }

            PFMC_AnswerA_Button.IsEnabled = false;
            PFMC_AnswerB_Button.IsEnabled = false;
            PFMC_AnswerC_Button.IsEnabled = false;
            PFMC_AnswerD_Button.IsEnabled = false;
        }

        private void PFMC_NextQuestion_Button_Click(object sender, RoutedEventArgs e)
        {
            PFMC__QuestionLabel.Visibility = Visibility.Visible;
            PFMC__WrongAnswerLabel.Visibility = Visibility.Hidden;
            PFMC__RightAnswerLabel.Visibility = Visibility.Hidden;
            PFMC__AnswerLabel.Visibility = Visibility.Hidden;
            PFMC__AnswerLabel.Content = "";
            PFMC_NextQuestion_Button.Visibility = Visibility.Hidden;

            PFMC_AnswerA_Button.IsEnabled = true;
            PFMC_AnswerB_Button.IsEnabled = true;
            PFMC_AnswerC_Button.IsEnabled = true;
            PFMC_AnswerD_Button.IsEnabled = true;

            Counter++;
            StartPlayingMC();
        }
        #endregion

        //Play TypeOut
        #region PlayTypeOut
        public void StartPlayingTO()
        {
            PFTO_PackLabel.Content = _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "World";

            if (Counter < _ActivePack.Length)
            {
                PFTO_Counter.Content = string.Format("{0}/{1}", Counter + 1, _ActivePack.Length);

                Random random = new Random();

                do
                {
                    int PickRandomFromPack = random.Next(_ActivePack.Length);
                    ActiveFlag = _ActivePack[PickRandomFromPack];
                } while (UsedFlags.Contains(ActiveFlag));

                UsedFlags.Add(ActiveFlag);
                PFTO_Flag.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png",ActiveFlag), UriKind.Absolute));
                PlayingField_TypeOut.Visibility = Visibility.Visible;
            }
            //End
            else
            {
                EndPF();
            }
        }
        #endregion

        //PlayingField_TypeOut
        #region PFTO
        public void PFTORightAnswer()
        {
            PFTO__QuestionLabel.Visibility = Visibility.Hidden;
            PFTO__RightAnswerLabel.Visibility = Visibility.Visible;
            PFTO_NextQuestion_Button.Visibility = Visibility.Visible;

            RightAnswers++;
        }

        public void PFTOWrongAnswer()
        {
            PFTO__QuestionLabel.Visibility = Visibility.Hidden;
            PFTO__WrongAnswerLabel.Visibility = Visibility.Visible;
            PFTO__AnswerLabel.Visibility = Visibility.Visible;
            PFTO__AnswerLabel.Content = ActiveFlag;
            PFTO_NextQuestion_Button.Visibility = Visibility.Visible;

            WrongAnswers++;
        }

        private void PFTO_AnswerBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PFTO_AnswerBox.Text = "";
        }

        private void PFTO_AnswerBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TOAnswer = PFTO_AnswerBox.Text;
        }

        private void PFTO_AnswerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (HasHitEnter)
                {
                    //Next Question
                    PFTO__QuestionLabel.Visibility = Visibility.Visible;
                    PFTO__WrongAnswerLabel.Visibility = Visibility.Hidden;
                    PFTO__RightAnswerLabel.Visibility = Visibility.Hidden;
                    PFTO__AnswerLabel.Visibility = Visibility.Hidden;
                    PFTO__AnswerLabel.Content = "";
                    PFTO_NextQuestion_Button.Visibility = Visibility.Hidden;
                    PFTO_AnswerBox.Text = "";

                    Counter++;
                    StartPlayingTO();
                    HasHitEnter = false;
                }
                else
                {
                    
                    if (string.Compare(TOAnswer, ActiveFlag, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                    {
                        PFTORightAnswer();
                    }
                    else
                    {
                        PFTOWrongAnswer();
                    }
                    HasHitEnter = true;
                }
            }
        }

        private void PFTO_NextQuestion_Button_Click(object sender, RoutedEventArgs e)
        {
            PFTO__QuestionLabel.Visibility = Visibility.Visible;
            PFTO__WrongAnswerLabel.Visibility = Visibility.Hidden;
            PFTO__RightAnswerLabel.Visibility = Visibility.Hidden;
            PFTO__AnswerLabel.Visibility = Visibility.Hidden;
            PFTO__AnswerLabel.Content = "";
            PFTO_NextQuestion_Button.Visibility = Visibility.Hidden;
            PFTO_AnswerBox.Text = "";

            Counter++;
            StartPlayingTO();
            HasHitEnter = false;
        }
        #endregion

        //Play ReverseMultipleChoice
        #region Play ReverseMultipleChoice
        public void StartPlayingRMC()
        {
            PFRMC_PackLabel.Content = _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "World";

            if (Counter < _ActivePack.Length)
            {
                PFRMC_Counter.Content = string.Format("{0}/{1}", Counter + 1, _ActivePack.Length);

                List<string> ActiveFlags = new List<string>();
                Random random = new Random();

                while (ActiveFlags.Count < 3)
                {
                    int PickRandomFromPack = random.Next(_ActivePack.Length);
                    string RandomPicked = _ActivePack[PickRandomFromPack];

                    if (ActiveFlags.Contains(RandomPicked))
                    {

                    }
                    else
                    {
                        ActiveFlags.Add(RandomPicked);
                    }
                }

                int NoDoubleCounter = 0;

                do
                {
                    if (NoDoubleCounter < 3)
                    {
                        int RandomIndexAF = random.Next(3);
                        ActiveFlag = ActiveFlags[RandomIndexAF];
                        MCAnswer = RandomIndexAF;
                        NoDoubleCounter++;
                    }
                    else
                    {
                        ActiveFlags.Clear();
                        while (ActiveFlags.Count < 3)
                        {
                            int PickRandomFromPack = random.Next(_ActivePack.Length);
                            string RandomPicked = _ActivePack[PickRandomFromPack];

                            if (ActiveFlags.Contains(RandomPicked))
                            {

                            }
                            else
                            {
                                ActiveFlags.Add(RandomPicked);
                                NoDoubleCounter = 0;
                            }
                        }
                    }
                } while (UsedFlags.Contains(ActiveFlag));

                UsedFlags.Add(ActiveFlag);

                PFRMC__QuestionCountryLabel.Content = string.Format("{0}?", ActiveFlag);
                PFRMC_AnswerC_Button.Content = ActiveFlags[0];
                PFRMC_FlagA.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", ActiveFlags[0]), UriKind.Absolute));
                PFRMC_AnswerB_Button.Content = ActiveFlags[1];
                PFRMC_FlagB.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", ActiveFlags[1]), UriKind.Absolute));
                PFRMC_AnswerC_Button.Content = ActiveFlags[2];
                PFRMC_FlagC.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", ActiveFlags[2]), UriKind.Absolute));

                PlayingField_ReverseMultipleChoice.Visibility = Visibility.Visible;
            }

            //End
            else
            {
                EndPF();
            }

        }
        #endregion

        //PlayingField_ReverseMultipleChoice
        #region PFMC
        public void PFRMCHighlightAnswer()
        {
            switch (MCAnswer)
            {
                case 0:
                    {
                        PFRMC_AnswerB_Button.Visibility = Visibility.Hidden;
                        PFRMC_FlagB.Visibility = Visibility.Hidden;
                        PFRMC_AnswerC_Button.Visibility = Visibility.Hidden;
                        PFRMC_FlagC.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        PFRMC_AnswerA_Button.Visibility = Visibility.Hidden;
                        PFRMC_FlagA.Visibility = Visibility.Hidden;
                        PFRMC_AnswerC_Button.Visibility = Visibility.Hidden;
                        PFRMC_FlagC.Visibility = Visibility.Hidden;
                        break;
                    }
                case 2:
                    {
                        PFRMC_AnswerA_Button.Visibility = Visibility.Hidden;
                        PFRMC_FlagA.Visibility = Visibility.Hidden;
                        PFRMC_AnswerB_Button.Visibility = Visibility.Hidden;
                        PFRMC_FlagB.Visibility = Visibility.Hidden;
                        break;
                    }
            }
        }

        public void PFRMCRightAnswer()
        {
            PFRMCHighlightAnswer();
            PFRMC__RightAnswerLabel.Visibility = Visibility.Visible;
            PFRMC_NextQuestion_Button.Visibility = Visibility.Visible;

            RightAnswers++;
        }

        public void PFRMCWrongAnswer()
        {
            PFRMCHighlightAnswer();
            PFRMC__WrongAnswerLabel.Visibility = Visibility.Visible;
            PFRMC_NextQuestion_Button.Visibility = Visibility.Visible;

            WrongAnswers++;
        }

        private void PFRMC_AnswerA_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 0)
            {
                PFRMCRightAnswer();
            }
            else
            {
                PFRMCWrongAnswer();
            }

            PFRMC_AnswerA_Button.IsEnabled = false;
            PFRMC_AnswerB_Button.IsEnabled = false;
            PFRMC_AnswerC_Button.IsEnabled = false;
        }

        private void PFRMC_AnswerB_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 1)
            {
                PFRMCRightAnswer();
            }
            else
            {
                PFRMCWrongAnswer();
            }

            PFRMC_AnswerA_Button.IsEnabled = false;
            PFRMC_AnswerB_Button.IsEnabled = false;
            PFRMC_AnswerC_Button.IsEnabled = false;
        }

        private void PFRMC_AnswerC_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MCAnswer == 2)
            {
                PFRMCRightAnswer();
            }
            else
            {
                PFRMCWrongAnswer();
            }

            PFRMC_AnswerA_Button.IsEnabled = false;
            PFRMC_AnswerB_Button.IsEnabled = false;
            PFRMC_AnswerC_Button.IsEnabled = false;
        }

        private void PFRMC_NextQuestion_Button_Click(object sender, RoutedEventArgs e)
        {
            PFRMC__QuestionLabel.Visibility = Visibility.Visible;
            PFRMC__WrongAnswerLabel.Visibility = Visibility.Hidden;
            PFRMC__RightAnswerLabel.Visibility = Visibility.Hidden;
            PFRMC_NextQuestion_Button.Visibility = Visibility.Hidden;

            PFRMC_AnswerA_Button.IsEnabled = true;
            PFRMC_AnswerB_Button.IsEnabled = true;
            PFRMC_AnswerC_Button.IsEnabled = true;

            PFRMC_AnswerA_Button.Visibility = Visibility.Visible;
            PFRMC_AnswerB_Button.Visibility = Visibility.Visible;
            PFRMC_AnswerC_Button.Visibility = Visibility.Visible;
            PFRMC_FlagA.Visibility = Visibility.Visible;
            PFRMC_FlagB.Visibility = Visibility.Visible;
            PFRMC_FlagC.Visibility = Visibility.Visible;

            Counter++;
            StartPlayingRMC();
        }
        #endregion

        //EscapeMenu
        #region EscapeMenu
        private void EM_MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ResetStuff();
            HideAllPages();
            MainMenu.Visibility = Visibility.Visible;
            EscapeMenuSmall.Visibility = Visibility.Visible;
        }

        private void EM_FP1MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ResetStuff();
            HideAllPages();
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
            EscapeMenuSmall.Visibility = Visibility.Visible;
        }

        private void EM_ModesMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ActivePack.Length > 1)
            {
                ResetStuff();
                HideAllPages();
                PAM_PackLabel.Content = _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "World";
                PickAModeMenu.Visibility = Visibility.Visible;
                EscapeMenuSmall.Visibility = Visibility.Visible;
            }
        }

        private void EM_ViewFlagsMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ActivePack.Length < 2)
            {
                _ActivePack = WorldPack;
            }
            ResetStuff();
            HideAllPages();
            EscapeMenuSmall.Visibility = Visibility.Visible;
            PlayOrView = "View";
            ViewFlagsPage();
        }

        private void EM_QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenEscapeMenuButton_Click(object sender, RoutedEventArgs e)
        {
            EscapeMenuLarge.Visibility = Visibility.Visible;
            EscapeMenuSmall.Visibility = Visibility.Hidden;
        }

        private void EM_CloseEscapeMenuButton_Click(object sender, RoutedEventArgs e)
        {
            EscapeMenuSmall.Visibility = Visibility.Visible;
            EscapeMenuLarge.Visibility = Visibility.Hidden;
        }
        #endregion

        //EndScreenMenu
        #region EndScreenMenu
        public void EndPF()
        {
            PlayingField_MultipleChoice.Visibility = Visibility.Hidden;

            EGS_FinishedLabel.Content = string.Format("You finished the {0}.", _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "South America");
            EGS_RightNumberLabel.Content = RightAnswers;
            EGS_WrongNumberLabel.Content = WrongAnswers;

            PlayingField_MultipleChoice.Visibility = Visibility.Hidden;
            PlayingField_TypeOut.Visibility = Visibility.Hidden;
            PlayingField_ReverseMultipleChoice.Visibility = Visibility.Hidden;

            EndGameScreen.Visibility = Visibility.Visible;
        }

        private void EGS_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            ResetStuff();

            EndGameScreen.Visibility = Visibility.Hidden;
            MainMenu.Visibility = Visibility.Visible;
        }

        private void EGS_TryAgain_Click(object sender, RoutedEventArgs e)
        {
            ResetStuff();

            if (ActiveMode == "MultipleChoice")
            {
                StartPlayingMC();
            }
            else if (ActiveMode == "TypeOut")
            {
                StartPlayingTO();
            }
            else if (ActiveMode == "ReverseMultipleChoice")
            {
                StartPlayingRMC();
            }
            EndGameScreen.Visibility = Visibility.Hidden;
        }

        private void EGS_TryDifferentPack_Click(object sender, RoutedEventArgs e)
        {
            ResetStuff();

            EndGameScreen.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
        }
        #endregion

        //PickAModeMenu
        #region PickAModeMenu
        private void PAM_MultipleChoice_Click(object sender, RoutedEventArgs e)
        {
            StartPlayingMC();
            PickAModeMenu.Visibility = Visibility.Hidden;
            ActiveMode = "MultipleChoice";
        }

        private void PAM_ReverseMultipleChoice_Click(object sender, RoutedEventArgs e)
        {
            StartPlayingRMC();
            PickAModeMenu.Visibility = Visibility.Hidden;
            ActiveMode = "ReverseMultipleChoice";
        }

        private void PAM_TypeOutMode_Click(object sender, RoutedEventArgs e)
        {
            StartPlayingTO();
            PickAModeMenu.Visibility = Visibility.Hidden;
            ActiveMode = "TypeOut";
        }

        private void PAM_Back_Click(object sender, RoutedEventArgs e)
        {
            PickAModeMenu.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
            PlayOrView = "Play";
        }
        #endregion

        //ViewFlagsMenu
        #region ViewFlagsMenu
        public void ViewFlagsPage()
        {
            ViewFlags.Visibility = Visibility.Visible;
            VF_PackLabel.Content = _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "World";

            VF_SetFlags(0);
        }

        public void VF_SetFlags(int Sender)
        {
            switch (Sender)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        VFPage--;
                        break;
                    }
                case 2:
                    {
                        VFPage++;
                        break;
                    }
            }

            //Page Count
            if (_ActivePack.Length % 15 == 0)
            {
                VF_Page.Content = string.Format("{0}/{1}", VFPage, _ActivePack.Length / 15);
            }
            else
            {
                VF_Page.Content = string.Format("{0}/{1}", VFPage, _ActivePack.Length / 15 + 1);
            }
            VF_BackAndPreviousButton();

            if (_ActivePack == AfricaPack && VFPage == 3)
            {
                VF_R3C5Label.RenderTransform = new TranslateTransform(39, 0);
            }
            else if (_ActivePack == WorldPack && VFPage == 13)
            {
                VF_R2C5Label.RenderTransform = new TranslateTransform(40, 0);
            }
            else if (_ActivePack == OrganizationsPack && VFPage == 1)
            {
                VF_R3C3Label.RenderTransform = new TranslateTransform(0, 30);
            }
            else if (_ActivePack == OrganizationsPack && VFPage == 2)
            {
                VF_R1C4Label.RenderTransform = new TranslateTransform(0, 15);
                VF_R1C5Label.RenderTransform = new TranslateTransform(0, -10);
            }
            else
            {
                VF_R3C3Label.RenderTransform = new TranslateTransform(0, 0);
                VF_R2C5Label.RenderTransform = new TranslateTransform(0, 0);
                VF_R3C5Label.RenderTransform = new TranslateTransform(0, 0);
                VF_R1C5Label.RenderTransform = new TranslateTransform(0, 0);
                VF_R1C4Label.RenderTransform = new TranslateTransform(0, 0);
            }

            if (VFPage * 15 > _ActivePack.Length)
            {
                for (int i = 0; i < (VFPage * 15) - _ActivePack.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                VF_R3C5Label.Visibility = Visibility.Hidden;
                                VF_R3C5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 1:
                            {
                                VF_R3C4Label.Visibility = Visibility.Hidden;
                                VF_R3C4.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 2:
                            {
                                VF_R3C3Label.Visibility = Visibility.Hidden;
                                VF_R3C3.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 3:
                            {
                                VF_R3C2Label.Visibility = Visibility.Hidden;
                                VF_R3C2.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 4:
                            {
                                VF_R3C1Label.Visibility = Visibility.Hidden;
                                VF_R3C1.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 5:
                            {
                                VF_R2C5Label.Visibility = Visibility.Hidden;
                                VF_R2C5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 6:
                            {
                                VF_R2C4Label.Visibility = Visibility.Hidden;
                                VF_R2C4.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 7:
                            {
                                VF_R2C3Label.Visibility = Visibility.Hidden;
                                VF_R2C3.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 8:
                            {
                                VF_R2C2Label.Visibility = Visibility.Hidden;
                                VF_R2C2.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 9:
                            {
                                VF_R2C1Label.Visibility = Visibility.Hidden;
                                VF_R2C1.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 10:
                            {
                                VF_R1C5Label.Visibility = Visibility.Hidden;
                                VF_R1C5.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 11:
                            {
                                VF_R1C4Label.Visibility = Visibility.Hidden;
                                VF_R1C4.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 12:
                            {
                                VF_R1C3Label.Visibility = Visibility.Hidden;
                                VF_R1C3.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 13:
                            {
                                VF_R1C2Label.Visibility = Visibility.Hidden;
                                VF_R1C2.Visibility = Visibility.Hidden;
                                break;
                            }
                        case 14:
                            {
                                VF_R1C1Label.Visibility = Visibility.Hidden;
                                VF_R1C1.Visibility = Visibility.Hidden;
                                break;
                            }
                    }
                }
                for (int i = 0; i < 15 - ((VFPage * 15) - _ActivePack.Length); i++)
                {
                    switch (i)
                    {
                        case 14:
                            {
                                VF_R3C5Label.Content = _ActivePack[(VFPage * 15) - 1];
                                VF_R3C5.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 1]), UriKind.Absolute));
                                break;
                            }
                        case 13:
                            {
                                VF_R3C4Label.Content = _ActivePack[(VFPage * 15) - 2];
                                VF_R3C4.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 2]), UriKind.Absolute));
                                break;
                            }
                        case 12:
                            {
                                VF_R3C3Label.Content = _ActivePack[(VFPage * 15) - 3];
                                VF_R3C3.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 3]), UriKind.Absolute));
                                break;
                            }
                        case 11:
                            {
                                VF_R3C2Label.Content = _ActivePack[(VFPage * 15) - 4];
                                VF_R3C2.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 4]), UriKind.Absolute));
                        break;
                            }
                        case 10:
                            {
                                VF_R3C1Label.Content = _ActivePack[(VFPage * 15) - 5];
                                VF_R3C1.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 5]), UriKind.Absolute));
                                break;
                            }
                        case 9:
                            {
                                VF_R2C5Label.Content = _ActivePack[(VFPage * 15) - 6];
                                VF_R2C5.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 6]), UriKind.Absolute));
                                break;
                            }
                        case 8:
                            {
                                VF_R2C4Label.Content = _ActivePack[(VFPage * 15) - 7];
                                VF_R2C4.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 7]), UriKind.Absolute));
                                break;
                            }
                        case 7:
                            {
                                VF_R2C3Label.Content = _ActivePack[(VFPage * 15) - 8];
                                VF_R2C3.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 8]), UriKind.Absolute));
                                break;
                            }
                        case 6:
                            {
                                VF_R2C2Label.Content = _ActivePack[(VFPage * 15) - 9];
                                VF_R2C2.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 9]), UriKind.Absolute));
                                break;
                            }
                        case 5:
                            {
                                VF_R2C1Label.Content = _ActivePack[(VFPage * 15) - 10];
                                VF_R2C1.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 10]), UriKind.Absolute));
                                break;
                            }
                        case 4:
                            {
                                VF_R1C5Label.Content = _ActivePack[(VFPage * 15) - 11];
                                VF_R1C5.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 11]), UriKind.Absolute));
                                break;
                            }
                        case 3:
                            {
                                VF_R1C4Label.Content = _ActivePack[(VFPage * 15) - 12];
                                VF_R1C4.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 12]), UriKind.Absolute));
                                break;
                            }
                        case 2:
                            {
                                VF_R1C3Label.Content = _ActivePack[(VFPage * 15) - 13];
                                VF_R1C3.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 13]), UriKind.Absolute));
                                break;
                            }
                        case 1:
                            {
                                VF_R1C2Label.Content = _ActivePack[(VFPage * 15) - 14];
                                VF_R1C2.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 14]), UriKind.Absolute));
                                break;
                            }
                        case 0:
                            {
                                VF_R1C1Label.Content = _ActivePack[(VFPage * 15) - 15];
                                VF_R1C1.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 15]), UriKind.Absolute));
                                break;
                            }
                    }
                }
            }
            else
            {
                VF_R1C1.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 15]), UriKind.Absolute));
                VF_R1C2.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 14]), UriKind.Absolute));
                VF_R1C3.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 13]), UriKind.Absolute));
                VF_R1C4.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 12]), UriKind.Absolute));
                VF_R1C5.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 11]), UriKind.Absolute));
                VF_R2C1.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 10]), UriKind.Absolute));
                VF_R2C2.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 9]), UriKind.Absolute));
                VF_R2C3.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 8]), UriKind.Absolute));
                VF_R2C4.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 7]), UriKind.Absolute));
                VF_R2C5.Source = _ActivePack == USStatesPack && VFPage == 1
                    ? new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_GeorgiaUS.png"), UriKind.Absolute))
                    : new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 6]), UriKind.Absolute));
                VF_R3C1.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 5]), UriKind.Absolute));
                VF_R3C2.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 4]), UriKind.Absolute));
                VF_R3C3.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 3]), UriKind.Absolute));
                VF_R3C4.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 2]), UriKind.Absolute));
                VF_R3C5.Source = new BitmapImage(new Uri(Path + string.Format("FlagsOfTheWorld_Flag_{0}.png", _ActivePack[(VFPage * 15) - 1]), UriKind.Absolute));


                //Labels
                VF_R1C1Label.Content = _ActivePack[(VFPage * 15) - 15];
                VF_R1C2Label.Content = _ActivePack[(VFPage * 15) - 14];
                VF_R1C3Label.Content = _ActivePack[(VFPage * 15) - 13];
                VF_R1C4Label.Content = _ActivePack[(VFPage * 15) - 12];
                VF_R1C5Label.Content = _ActivePack[(VFPage * 15) - 11];
                VF_R2C1Label.Content = _ActivePack[(VFPage * 15) - 10];
                VF_R2C2Label.Content = _ActivePack[(VFPage * 15) - 9];
                VF_R2C3Label.Content = _ActivePack[(VFPage * 15) - 8];
                VF_R2C4Label.Content = _ActivePack[(VFPage * 15) - 7];
                VF_R2C5Label.Content = _ActivePack[(VFPage * 15) - 6];
                VF_R3C1Label.Content = _ActivePack[(VFPage * 15) - 5];
                VF_R3C2Label.Content = _ActivePack[(VFPage * 15) - 4];
                VF_R3C3Label.Content = _ActivePack[(VFPage * 15) - 3];
                VF_R3C4Label.Content = _ActivePack[(VFPage * 15) - 2];
                VF_R3C5Label.Content = _ActivePack[(VFPage * 15) - 1];
            }
        }

        public void VF_BackAndPreviousButton()
        {
            if (_ActivePack.Length % 15 == 0)
            {
                if (VFPage == 1)
                {
                    VF_NextPage.Visibility = Visibility.Hidden;
                }
                else
                {
                    VF_NextPage.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (VFPage == _ActivePack.Length / 15 + 1)
                {
                    VF_NextPage.Visibility = Visibility.Hidden;
                }
                else
                {
                    VF_NextPage.Visibility = Visibility.Visible;
                }
            }

            if (VFPage == 1)
            {
                VF_PreviousPage.Visibility = Visibility.Hidden;
            }
            else
            {
                VF_PreviousPage.Visibility = Visibility.Visible;
            }

        }

        public void VF_ResetVisibility()
        {
            VF_R1C1Label.Visibility = Visibility.Visible;
            VF_R1C2Label.Visibility = Visibility.Visible;
            VF_R1C3Label.Visibility = Visibility.Visible;
            VF_R1C4Label.Visibility = Visibility.Visible;
            VF_R1C5Label.Visibility = Visibility.Visible;
            VF_R2C1Label.Visibility = Visibility.Visible;
            VF_R2C2Label.Visibility = Visibility.Visible;
            VF_R2C3Label.Visibility = Visibility.Visible;
            VF_R2C4Label.Visibility = Visibility.Visible;
            VF_R2C5Label.Visibility = Visibility.Visible;
            VF_R3C1Label.Visibility = Visibility.Visible;
            VF_R3C2Label.Visibility = Visibility.Visible;
            VF_R3C3Label.Visibility = Visibility.Visible;
            VF_R3C4Label.Visibility = Visibility.Visible;
            VF_R3C5Label.Visibility = Visibility.Visible;
            VF_R1C1.Visibility = Visibility.Visible;
            VF_R1C2.Visibility = Visibility.Visible;
            VF_R1C3.Visibility = Visibility.Visible;
            VF_R1C4.Visibility = Visibility.Visible;
            VF_R1C5.Visibility = Visibility.Visible;
            VF_R2C1.Visibility = Visibility.Visible;
            VF_R2C2.Visibility = Visibility.Visible;
            VF_R2C3.Visibility = Visibility.Visible;
            VF_R2C4.Visibility = Visibility.Visible;
            VF_R2C5.Visibility = Visibility.Visible;
            VF_R3C1.Visibility = Visibility.Visible;
            VF_R3C2.Visibility = Visibility.Visible;
            VF_R3C3.Visibility = Visibility.Visible;
            VF_R3C4.Visibility = Visibility.Visible;
            VF_R3C5.Visibility = Visibility.Visible;

        }

        private void VF_Back_Click(object sender, RoutedEventArgs e)
        {
            VFPage = 1;
            VF_ResetVisibility();
            ViewFlags.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Visible;
            PlayOrView = "View";
        }

        private void VF_PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            VF_ResetVisibility();
            VF_SetFlags(1);
        }

        private void VF_NextPage_Click(object sender, RoutedEventArgs e)
        {
            VF_ResetVisibility();
            VF_SetFlags(2);
        }
        #endregion

        //PlayOrView
        #region PlayOrView
        public void PlayOrViewMethod()
        {
            if (PlayOrView == "Play")
            {
                HideAllPages();
                PAM_PackLabel.Content = _ActivePack == AfricaPack ? "Africa" : _ActivePack == AsiaPack ? "Asia" : _ActivePack == EuropePack ? "Europe" : _ActivePack == NorthAmericaPack ? "North America" : _ActivePack == OceaniaPack ? "Oceania" : _ActivePack == SouthAmericaPack ? "South America" : _ActivePack == WorldPack ? "World" : _ActivePack == USStatesPack ? "US States" : _ActivePack == OrganizationsPack ? "Organizations" : "World";
                PickAModeMenu.Visibility = Visibility.Visible;
                FlagPackMenu_Page1.Visibility = Visibility.Hidden;
                FlagPackMenu_Page2.Visibility = Visibility.Hidden;
            }
            else if (PlayOrView == "View")
            {
                HideAllPages();
                ViewFlagsPage();
                FlagPackMenu_Page1.Visibility = Visibility.Hidden;
                FlagPackMenu_Page2.Visibility = Visibility.Hidden;
            }
            else
            {
                FPM_PlayOrView.Visibility = Visibility.Visible;
            }
        }

        private void FPM_POV_ViewButton_Click(object sender, RoutedEventArgs e)
        {
            PlayOrView = "View";
            PlayOrViewMethod();
        }

        private void FPM_POV_PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayOrView = "Play";
            PlayOrViewMethod();
        }

        private void FPM_POV_BackButton_Click(object sender, RoutedEventArgs e)
        {
            FPM_PlayOrView.Visibility = Visibility.Hidden;
        }
        #endregion

        //ExtraStuff
        public void HideAllPages()
        {
            MainMenu.Visibility = Visibility.Hidden;
            PickAModeMenu.Visibility = Visibility.Hidden;
            PlayingField_MultipleChoice.Visibility = Visibility.Hidden;
            PlayingField_TypeOut.Visibility = Visibility.Hidden;
            PlayingField_ReverseMultipleChoice.Visibility = Visibility.Hidden;
            FlagPackMenu_Page1.Visibility = Visibility.Hidden;
            FlagPackMenu_Page2.Visibility = Visibility.Hidden;
            ViewFlags.Visibility = Visibility.Hidden;
            EndGameScreen.Visibility = Visibility.Hidden;
            EscapeMenuLarge.Visibility = Visibility.Hidden;
            FPM_PlayOrView.Visibility = Visibility.Hidden;
        }

        public void ResetStuff()
        {
            VFPage = 1;
            Counter = 0;
            UsedFlags.Clear();
            RightAnswers = 0;
            WrongAnswers = 0;
            HasHitEnter = false;
            VF_R3C3Label.RenderTransform = new TranslateTransform(0, 0);
            VF_R2C5Label.RenderTransform = new TranslateTransform(0, 0);
            VF_R3C5Label.RenderTransform = new TranslateTransform(0, 0);
            VF_R1C5Label.RenderTransform = new TranslateTransform(0, 0);
            VF_R1C4Label.RenderTransform = new TranslateTransform(0, 0);
        }
    }
}
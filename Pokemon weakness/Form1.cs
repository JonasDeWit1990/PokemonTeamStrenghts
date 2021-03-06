﻿///Program: Pokemon weakness calculator
///summary: A simple program to calculate the weakness and strenght of a Pokemon team
///Author: Jonas De Wit
///Type of program: this is a freeware program, meaning source code is included

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokemon_weakness
{
    /// <summary>
    /// Converts an integer to a pokemon type and vice versa
    /// using (int) and (PokeTypeSelection)
    /// </summary>
    enum PokeTypeSelection
    {
        None = -1, // used for 2nd type
        Normal = 0,
        Fire = 1,
        Water = 2,
        Electric = 3,
        Grass = 4,
        Ice = 5,
        Fighting = 6,
        Poison = 7,
        Ground = 8,
        Flying = 9,
        Psychic = 10,
        Bug = 11,
        Rock = 12,
        Ghost = 13,
        Dragon = 14,
        Dark = 15,
        Steel = 16,
        Fairy = 17,
    }

    public partial class Form1 : Form
    {
        // initialise all pokemon types
        PokemonType Normal = new PokemonType();
        PokemonType Fire = new PokemonType();
        PokemonType Water = new PokemonType();
        PokemonType Electric = new PokemonType();
        PokemonType Grass = new PokemonType();
        PokemonType Ice = new PokemonType();
        PokemonType Fighting = new PokemonType();
        PokemonType Poison = new PokemonType();
        PokemonType Ground = new PokemonType();
        PokemonType Flying = new PokemonType();
        PokemonType Psychic = new PokemonType();
        PokemonType Bug = new PokemonType();
        PokemonType Rock = new PokemonType();
        PokemonType Ghost = new PokemonType();
        PokemonType Dragon = new PokemonType();
        PokemonType Dark = new PokemonType();
        PokemonType Steel = new PokemonType();
        PokemonType Fairy = new PokemonType();

        //initialise all pokemon and there (possible) 2 types
        PokemonType[] Pokemon1 = new PokemonType[2];
        PokemonType[] Pokemon2 = new PokemonType[2];
        PokemonType[] Pokemon3 = new PokemonType[2];
        PokemonType[] Pokemon4 = new PokemonType[2];
        PokemonType[] Pokemon5 = new PokemonType[2];
        PokemonType[] Pokemon6 = new PokemonType[2];

        // array of string used to update the viewgrid
        string[] Pokemon1Weak = {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"};
        string[] Pokemon2Weak = { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
        string[] Pokemon3Weak = { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
        string[] Pokemon4Weak = { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
        string[] Pokemon5Weak = { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
        string[] Pokemon6Weak = { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };

        // string array used to incorporate Abilities
        string[] PokemonAbilities = { "", "", "", "", "", "" };

        //List used to populate the comboboxes
        List<PokemonBase> PokemonList = new List<PokemonBase>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises the weakness/strenghts of each type
        /// </summary>
        private void SetWeakness()
        {
            Normal.Fighting = 2;
            Normal.Ghost = 0;
            
            Fire.Fire = 3;
            Fire.Water = 2;
            Fire.Grass = 3;
            Fire.Ice = 3;
            Fire.Ground = 2;
            Fire.Bug = 3;
            Fire.Rock = 2;
            Fire.Steel = 3;
            Fire.Fairy = 3;

            Water.Fire = 3;
            Water.Water = 3;
            Water.Electric = 2;
            Water.Grass = 2;
            Water.Ice = 3;
            Water.Steel = 3;
            
            Electric.Electric = 3;
            Electric.Ground = 2;
            Electric.Flying = 3;
            Electric.Steel = 3;
            
            Grass.Fire = 2;
            Grass.Water = 3;
            Grass.Electric = 3;
            Grass.Grass = 3;
            Grass.Ice = 2;
            Grass.Poison = 2;
            Grass.Ground = 3;
            Grass.Flying = 2;
            Grass.Bug = 2;
            
            Ice.Fire = 2;
            Ice.Ice = 3;
            Ice.Fighting = 2;
            Ice.Rock = 2;
            Ice.Steel = 2;
            
            Fighting.Flying = 2;
            Fighting.Psychic = 2;
            Fighting.Bug = 3;
            Fighting.Rock = 3;
            Fighting.Dark = 3;
            Fighting.Fairy = 2;

            Poison.Grass = 3;
            Poison.Fighting = 3;
            Poison.Poison = 3;
            Poison.Ground = 2;
            Poison.Psychic = 2;
            Poison.Bug = 3;
            Poison.Fairy = 3;

            Ground.Water = 2;
            Ground.Electric = 0;
            Ground.Grass = 2;
            Ground.Ice = 2;
            Ground.Poison = 3;
            Ground.Rock = 3;
            
            Flying.Electric = 2;
            Flying.Grass = 3;
            Flying.Ice = 2;
            Flying.Fighting = 3;
            Flying.Ground = 0;
            Flying.Bug = 3;
            Flying.Rock = 2;
            
            Psychic.Fighting = 3;
            Psychic.Psychic = 3;
            Psychic.Bug = 2;
            Psychic.Ghost = 2;
            Psychic.Dark = 2;
            
            Bug.Fire = 2;
            Bug.Grass = 3;
            Bug.Fighting = 3;
            Bug.Ground = 3;
            Bug.Flying = 2;
            Bug.Rock = 2;
            
            Rock.Normal = 3;
            Rock.Fire = 3;
            Rock.Water = 2;
            Rock.Grass = 2;
            Rock.Fighting = 2;
            Rock.Poison = 3;
            Rock.Ground = 2;
            Rock.Flying = 3;
            Rock.Steel = 2;
            
            Ghost.Normal = 0;
            Ghost.Fighting = 0;
            Ghost.Poison = 3;
            Ghost.Bug = 3;
            Ghost.Ghost = 2;
            Ghost.Dark = 2;
            
            Dragon.Fire = 3;
            Dragon.Water = 3;
            Dragon.Electric = 3;
            Dragon.Grass = 3;
            Dragon.Ice = 2;
            Dragon.Dragon = 2;
            Dragon.Fairy = 2;

            Dark.Fighting = 2;
            Dark.Psychic = 0;
            Dark.Bug = 2;
            Dark.Ghost = 3;
            Dark.Fairy = 2;

            Steel.Normal = 3;
            Steel.Fire = 2;
            Steel.Grass = 3;
            Steel.Ice = 3;
            Steel.Fighting = 2;
            Steel.Poison = 0;
            Steel.Ground = 2;
            Steel.Flying = 3;
            Steel.Psychic = 3;
            Steel.Bug = 3;
            Steel.Rock = 3;
            Steel.Dragon = 3;
            Steel.Steel = 3;
            Steel.Fairy = 3;

            Fairy.Fighting = 3;
            Fairy.Poison = 2;
            Fairy.Bug = 3;
            Fairy.Dragon = 0;
            Fairy.Dark = 3;
            Fairy.Steel = 2;
        }

        /// <summary>
        /// Reads all pokemonNames from a file named AllPokemon.txt
        /// this contains in this order: ID -> Name -> Type1 -> (optional)Type2 -> Ability1 -> (optional)Ability2 -> (optional)HiddenAbility
        /// seperated by a \t. ended by a \n    
        /// </summary>
        private void SetPokemonNamesinClass()
        {
            string Filename = @"Pokemons.tsv";
           
            if (File.Exists(Filename))
            {
                string[] Lines = File.ReadAllLines(Filename);

                foreach (string Line in Lines)
                {
                    
                    string[] Splitter = Line.Split('\t');

                    PokeTypeSelection FoundType, FoundType2;
                    Enum.TryParse(Splitter[2], out FoundType);

                    if (Splitter[3] != "")
                        Enum.TryParse(Splitter[3], out FoundType2);
                    else
                        FoundType2 = (PokeTypeSelection)(-1);

                    PokemonList.Add(new PokemonBase(Convert.ToInt16(Splitter[0]), Splitter[1], FoundType, FoundType2,Splitter[4],Splitter[5],Splitter[6]));
                    
                    
                }

            }
            else
                MessageBox.Show("error reading file");
        }

        /// <summary>
        /// This Method translates the WeaknessCode into the appropriate string and typing
        /// </summary>
        /// <param name="Poketype">Gives the Type to be used in the string</param>
        /// <param name="WeaknessCode">The integer code (0,1,2,3,4,6,9) to be translated into a string</param>
        /// <returns>translated code into a string</returns>
        private string WeaknessCodeIntoString(string Weakness)
        {
            switch(Convert.ToInt32(Weakness))
            {
                case 0:
                    {
                        return "0";
                    }
                case 1:
                    {
                        return "1";
                    }
                case 2:
                    {
                        return "2";
                    }
                case 3:
                    {
                        return "1/2";
                    }
                case 4:
                    {
                        return "4";
                    }
                case 6:
                    {
                        return "1";
                    }
                case 9:
                    {
                        return "1/4";
                    }
                default:
                    return "something went wrong";
            }
        }

        /// <summary>
        /// Updates the DisplayString
        /// </summary>
        private string[] CalculateWeaknessForPokemon(PokemonType[] Pokemon)
        {
            string[] DisplayString = new string[18];
            {
                int Weakness;
                Weakness = Pokemon[0].Normal * Pokemon[1].Normal;
                DisplayString[0] = Weakness.ToString();
                Weakness = Pokemon[0].Fire * Pokemon[1].Fire;
                DisplayString[1] = Weakness.ToString();
                Weakness = Pokemon[0].Water * Pokemon[1].Water;
                DisplayString[2] = Weakness.ToString();
                Weakness = Pokemon[0].Electric * Pokemon[1].Electric;
                DisplayString[3] = Weakness.ToString();
                Weakness = Pokemon[0].Grass * Pokemon[1].Grass;
                DisplayString[4] = Weakness.ToString();
                Weakness = Pokemon[0].Ice * Pokemon[1].Ice;
                DisplayString[5] = Weakness.ToString();
                Weakness = Pokemon[0].Fighting * Pokemon[1].Fighting;
                DisplayString[6] = Weakness.ToString();
                Weakness = Pokemon[0].Poison * Pokemon[1].Poison;
                DisplayString[7] = Weakness.ToString();
                Weakness = Pokemon[0].Ground * Pokemon[1].Ground;
                DisplayString[8] = Weakness.ToString();
                Weakness = Pokemon[0].Flying * Pokemon[1].Flying;
                DisplayString[9] = Weakness.ToString();
                Weakness = Pokemon[0].Psychic * Pokemon[1].Psychic;
                DisplayString[10] = Weakness.ToString();
                Weakness = Pokemon[0].Bug * Pokemon[1].Bug;
                DisplayString[11] = Weakness.ToString();
                Weakness = Pokemon[0].Rock * Pokemon[1].Rock;
                DisplayString[12] = Weakness.ToString();
                Weakness = Pokemon[0].Ghost * Pokemon[1].Ghost;
                DisplayString[13] = Weakness.ToString();
                Weakness = Pokemon[0].Dragon * Pokemon[1].Dragon;
                DisplayString[14] = Weakness.ToString();
                Weakness = Pokemon[0].Dark * Pokemon[1].Dark;
                DisplayString[15] = Weakness.ToString();
                Weakness = Pokemon[0].Steel * Pokemon[1].Steel;
                DisplayString[16] = Weakness.ToString();
                Weakness = Pokemon[0].Fairy * Pokemon[1].Fairy;
                DisplayString[17] = Weakness.ToString();
            }

            return DisplayString;
        }

        /// <summary>
        /// Loops through the different types to set the strenght/weakness of the pokemon.
        ///     first it sets it for all pokemons (the i-loop)
        ///     then it sets the color code for the strenght/weakness (the j-loop in the i-loop)
        ///     finally it calculates the sum, sets it, and colors it
        /// </summary>
        private void UpdateWeaknessGridView()
        {
            WeaknessGrid.Rows.Clear();
            chart1.Series[0].Points.Clear();
            int WeaknessCount = 0, StrenghtCount = 0;

            for (int i = 0; i < 18; i++)
            {
                string[] Inputstring = { ((PokeTypeSelection)i).ToString(), WeaknessCodeIntoString(Pokemon1Weak[i]), WeaknessCodeIntoString(Pokemon2Weak[i]), 
                                          WeaknessCodeIntoString(Pokemon3Weak[i]), WeaknessCodeIntoString(Pokemon4Weak[i]),
                                          WeaknessCodeIntoString(Pokemon5Weak[i]), WeaknessCodeIntoString(Pokemon6Weak[i]), "Sum" };

                //TODO (jonas) Add in Ability support here
                // go through each pokemon ability
                for (int Index = 0; Index < 6; Index++)
                {
                    if (PokemonAbilities[Index] == "Dry Skin" && (PokeTypeSelection)i == PokeTypeSelection.Water)
                        Inputstring[Index + 1] = "0";

                    if ((PokemonAbilities[Index] == "Filter" || PokemonAbilities[Index] == "Solid Rock") && Inputstring[Index + 1] == "2")
                        Inputstring[Index + 1] = "3/2";
                    else if ((PokemonAbilities[Index] == "Filter" || PokemonAbilities[Index] == "Solid Rock") && Inputstring[Index + 1] == "4")
                        Inputstring[Index + 1] = "3";

                    if (PokemonAbilities[Index] == "Flash Fire" && (PokeTypeSelection)i == PokeTypeSelection.Fire)
                        Inputstring[Index + 1] = "0";

                    if (PokemonAbilities[Index] == "Heatproof" && (PokeTypeSelection)i == PokeTypeSelection.Fire && Inputstring[Index + 1] == "1")
                        Inputstring[Index + 1] = "1/2";
                    else if (PokemonAbilities[Index] == "Heatproof" && (PokeTypeSelection)i == PokeTypeSelection.Fire && Inputstring[Index + 1] == "2")
                        Inputstring[Index + 1] = "1";
                    else if (PokemonAbilities[Index] == "Heatproof" && (PokeTypeSelection)i == PokeTypeSelection.Fire && Inputstring[Index + 1] == "4")
                        Inputstring[Index + 1] = "2";

                    if (PokemonAbilities[Index] == "Levitate" && (PokeTypeSelection)i == PokeTypeSelection.Ground)
                        Inputstring[Index + 1] = "0";

                    if (PokemonAbilities[Index] == "Motor Drive" && (PokeTypeSelection)i == PokeTypeSelection.Electric)
                        Inputstring[Index + 1] = "0";

                    if (PokemonAbilities[Index] == "Thick Fat" && ((PokeTypeSelection)i == PokeTypeSelection.Fire || (PokeTypeSelection)i == PokeTypeSelection.Ice) &&
                        Inputstring[Index + 1] == "1")
                        Inputstring[Index + 1] = "1/2";
                    else if (PokemonAbilities[Index] == "Thick Fat" && ((PokeTypeSelection)i == PokeTypeSelection.Fire || (PokeTypeSelection)i == PokeTypeSelection.Ice) &&
                             Inputstring[Index + 1] == "2")
                        Inputstring[Index + 1] = "1";
                    else if (PokemonAbilities[Index] == "Thick Fat" && ((PokeTypeSelection)i == PokeTypeSelection.Fire || (PokeTypeSelection)i == PokeTypeSelection.Ice ) && 
                             Inputstring[Index + 1] == "4")
                        Inputstring[Index + 1] = "2";

                    if (PokemonAbilities[Index] == "Volt Absorb" && (PokeTypeSelection)i == PokeTypeSelection.Electric)
                        Inputstring[Index + 1] = "0";

                    if (PokemonAbilities[Index] == "Water Absorb" && (PokeTypeSelection)i == PokeTypeSelection.Water)
                        Inputstring[Index + 1] = "0";

                    if (PokemonAbilities[Index] == "Wonder Guard" && (Inputstring[Index + 1] == "1" || Inputstring[Index + 1] == "1/2" || Inputstring[Index + 1] == "1/4"))
                        Inputstring[Index + 1] = "0";
                }

                WeaknessGrid.Rows.Add(Inputstring);
                WeaknessCount = 0;
                StrenghtCount = 0;
                for (int j = 1; j < 7; j++)
                {
                    switch (WeaknessGrid.Rows[i].Cells[j].Value.ToString())
                    {
                        case "0":
                            {
                                WeaknessGrid.Rows[i].Cells[j].Style.BackColor = Color.DarkGreen;
                                WeaknessGrid.Rows[i].Cells[j].Style.ForeColor = Color.White;
                                StrenghtCount++;
                            }break;
                        case "1/4":
                            {
                                WeaknessGrid.Rows[i].Cells[j].Style.BackColor = Color.Green;
                                WeaknessGrid.Rows[i].Cells[j].Style.ForeColor = Color.White;
                                StrenghtCount++;
                            }break;
                        case "1/2":
                            {
                                WeaknessGrid.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                                //WeaknessGrid.Rows[i].Cells[j].Style.ForeColor = Color.White;
                                StrenghtCount++;
                            }break;
                        case "3/2":
                        case "2":
                            {
                                WeaknessGrid.Rows[i].Cells[j].Style.BackColor = Color.OrangeRed;
                                WeaknessGrid.Rows[i].Cells[j].Style.ForeColor = Color.White;
                                WeaknessCount++;
                            }break;
                        case "3":
                        case "4":
                            {
                                WeaknessGrid.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                WeaknessGrid.Rows[i].Cells[j].Style.ForeColor = Color.White;
                                WeaknessCount++;
                            }break;
                        default:
                            break;

                    }// end switch
                }// end for loop (row)

                WeaknessGrid.Rows[i].Cells[7].Value = (StrenghtCount - WeaknessCount).ToString();

                if ((StrenghtCount - WeaknessCount ) > 0)
                {
                    WeaknessGrid.Rows[i].Cells[7].Style.BackColor = Color.DarkGreen;
                    WeaknessGrid.Rows[i].Cells[7].Style.ForeColor = Color.White;
                }
                else if ((StrenghtCount - WeaknessCount) < 0)
                {
                    WeaknessGrid.Rows[i].Cells[7].Style.BackColor = Color.Red;
                    WeaknessGrid.Rows[i].Cells[7].Style.ForeColor = Color.White;
                }

                chart1.Series[0].Points.AddXY(i,StrenghtCount - WeaknessCount);
                if (chart1.Series[0].Points[i].YValues[0] < 0)
                {
                    chart1.Series[0].Points[i].Color = Color.Red;
                }
                //chart1.Series[1].Points.AddXY(i, WeaknessCount);
                chart1.Series[0].Points[i].AxisLabel = ((PokeTypeSelection)i).ToString();

            }// end for loop (table)
        }

        /// <summary>
        /// Check Rows and counters for strenght and weakness and sets the colors
        /// </summary>
        /// <param name="TypeWeakness"></param>
        /// <param name="TypeStrength"></param>
        /// <param name="TypeImmunity"></param>
        /// <returns></returns>
        private void CheckPokemontype( int[] TypeWeakness, int[] TypeStrenght, int[]TypeImmunity)
        {
            bool Weak = false, Strong = false;
            int result = 0;

            for (int Row = 0; Row < 18; Row++)
            {
                foreach (int Type in TypeImmunity)
                {
                    if (MoveStrenght_grid.Rows[Type].Cells[Row + 1].Style.BackColor != Color.Green)
                    {
                        MoveStrenght_grid.Rows[Type].Cells[Row + 1].Style.BackColor = Color.Red;
                        MoveStrenght_grid.Rows[Row].Cells[Type + 1].Style.BackColor = Color.Red;
                    }
                }

                for (int Column = 0; Column < 18; Column++)
                {
                    Weak = false;
                    Strong = false;
                    result = 0;

                    foreach (int Type in TypeWeakness)
                    {
                        if (Type == Column || Type == Row)
                            Weak = true;
                    }

                    foreach (int Type in TypeStrenght)
                    {
                        if (Type == Column || Type == Row)
                            Strong = true;
                    }

                    if (Weak == true && Strong == false)
                        result = 1;
                    else if (Weak == false && Strong == true)
                        result = 2;

                    if (MoveStrenght_grid.Rows[Row].Cells[Column + 1].Style.BackColor != Color.Green)
                    {
                        if (result == 1)
                            MoveStrenght_grid.Rows[Row].Cells[Column + 1].Style.BackColor = Color.Red;
                        else if (result == 2)
                            MoveStrenght_grid.Rows[Row].Cells[Column + 1].Style.BackColor = Color.Green;
                    }
                }

            }
        }

        /// <summary>
        /// Loop through every Type_check to adjust the table in the corresponding strenghts and weaknesses.
        /// </summary>
        private void UpdateStrengthGridView()
        {
            for (int i = 0; i < 18; i++)
                for (int j = 0; j < 18; j++)
                    MoveStrenght_grid.Rows[i].Cells[j + 1].Style.BackColor = Color.White;

            //normalcheck
            if (Normal_check.Checked == true)
            {
                int[] Strength = { };
                int[] Weakness = { (int)PokeTypeSelection.Rock, (int)PokeTypeSelection.Steel, (int)PokeTypeSelection.Ghost };
                int[] Immunity = { (int)PokeTypeSelection.Ghost };

                CheckPokemontype(Weakness, Strength, Immunity);
            } // end normal check
            
            //firecheck
            if (Fire_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Ice, (int)PokeTypeSelection.Bug, (int)PokeTypeSelection.Steel };
                int[] Weakness = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Rock, (int)PokeTypeSelection.Water, (int)PokeTypeSelection.Dragon };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            } // end Fire check

            //watercheck
            if (Water_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Ground, (int)PokeTypeSelection.Rock };
                int[] Weakness = { (int)PokeTypeSelection.Water, (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Dragon };
                int[] Immunity = { };

                CheckPokemontype(Weakness, Strength, Immunity);
            } // end Water Check

            //electriccheck
            if (Electric_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Water, (int)PokeTypeSelection.Flying, (int)PokeTypeSelection.Rock };
                int[] Weakness = { (int)PokeTypeSelection.Ground, (int)PokeTypeSelection.Electric, (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Dragon };
                int[] Immunity = { (int)PokeTypeSelection.Ground }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Electric check

            //grasscheck
            if (Grass_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Water, (int)PokeTypeSelection.Ground, (int)PokeTypeSelection.Rock };
                int[] Weakness = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Poison, (int)PokeTypeSelection.Flying,
                                   (int)PokeTypeSelection.Bug, (int)PokeTypeSelection.Dragon, (int)PokeTypeSelection.Steel };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Grass check

            //icecheck
            if (Ice_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Ground, (int)PokeTypeSelection.Flying, (int)PokeTypeSelection.Dragon };
                int[] Weakness = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Water, (int)PokeTypeSelection.Ice, (int)PokeTypeSelection.Steel };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Ice check

            //fightingcheck
            if (Fighting_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Normal, (int)PokeTypeSelection.Ice, (int)PokeTypeSelection.Rock, (int)PokeTypeSelection.Dark,
                                   (int)PokeTypeSelection.Steel};
                int[] Weakness = { (int)PokeTypeSelection.Ghost, (int)PokeTypeSelection.Poison, (int)PokeTypeSelection.Flying, (int)PokeTypeSelection.Psychic,
                                   (int)PokeTypeSelection.Bug, (int)PokeTypeSelection.Fairy};
                int[] Immunity = { (int)PokeTypeSelection.Ghost }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Fighting check
        
            //Poisoncheck
            if (Poison_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Fairy };
                int[] Weakness = { (int)PokeTypeSelection.Steel, (int)PokeTypeSelection.Poison, (int)PokeTypeSelection.Ground, (int)PokeTypeSelection.Rock,
                                   (int)PokeTypeSelection.Ghost };
                int[] Immunity = { (int)PokeTypeSelection.Steel }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Poison check

            //Groundcheck
            if (Ground_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Electric, (int)PokeTypeSelection.Poison, (int)PokeTypeSelection.Rock,
                                   (int)PokeTypeSelection.Steel };
                int[] Weakness = { (int)PokeTypeSelection.Flying, (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Bug };
                int[] Immunity = { (int)PokeTypeSelection.Flying }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Ground check

            //Flyingcheck
            if (Flying_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Fighting, (int)PokeTypeSelection.Bug };
                int[] Weakness = { (int)PokeTypeSelection.Electric, (int)PokeTypeSelection.Rock, (int)PokeTypeSelection.Steel };
                int[] Immunity = { };

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Flying check

            //Psychiccheck
            if (Psychic_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Fighting, (int)PokeTypeSelection.Poison };
                int[] Weakness = { (int)PokeTypeSelection.Dark, (int)PokeTypeSelection.Psychic, (int)PokeTypeSelection.Steel };
                int[] Immunity = { (int)PokeTypeSelection.Dark };

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Psychic check

            //Bugcheck
            if (Bug_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Grass, (int)PokeTypeSelection.Psychic, (int)PokeTypeSelection.Dark };
                int[] Weakness = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Fighting, (int)PokeTypeSelection.Poison, (int)PokeTypeSelection.Flying,
                                   (int)PokeTypeSelection.Ghost, (int)PokeTypeSelection.Steel, (int)PokeTypeSelection.Fairy };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Bug check

            //Rockcheck
            if (Rock_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Ice, (int)PokeTypeSelection.Flying, (int)PokeTypeSelection.Bug };
                int[] Weakness = { (int)PokeTypeSelection.Fighting, (int)PokeTypeSelection.Ground, (int)PokeTypeSelection.Steel };
                int[] Immunity = { };

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Rock check

            //Ghostcheck
            if (Ghost_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Psychic, (int)PokeTypeSelection.Ghost };
                int[] Weakness = { (int)PokeTypeSelection.Dark, (int)PokeTypeSelection.Normal };
                int[] Immunity = { (int)PokeTypeSelection.Normal }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Ghost check

            //Dragoncheck
            if (Dragon_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Dragon };
                int[] Weakness = { (int)PokeTypeSelection.Steel, (int)PokeTypeSelection.Fairy };
                int[] Immunity = { (int)PokeTypeSelection.Fairy }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Dragon check

            //Darkcheck
            if (Dark_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Psychic, (int)PokeTypeSelection.Ghost };
                int[] Weakness = { (int)PokeTypeSelection.Fighting, (int)PokeTypeSelection.Dark, (int)PokeTypeSelection.Fairy };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Dark check

            //Steelcheck
            if (Steel_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Ice, (int)PokeTypeSelection.Rock, (int)PokeTypeSelection.Fairy };
                int[] Weakness = { (int)PokeTypeSelection.Fire, (int)PokeTypeSelection.Water, (int)PokeTypeSelection.Electric, (int)PokeTypeSelection.Steel };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
                
            }// end Steel check

            //Fairycheck
            if (Fairy_check.Checked == true)
            {
                int[] Strength = { (int)PokeTypeSelection.Dragon, (int)PokeTypeSelection.Fighting, (int)PokeTypeSelection.Dark };
                int[] Weakness = { (int)PokeTypeSelection.Steel, (int)PokeTypeSelection.Poison, (int)PokeTypeSelection.Fire };
                int[] Immunity = { }; 

                CheckPokemontype(Weakness, Strength, Immunity);
            }// end Fairy check
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonStrenght_btn.Enabled = true;
            PokemonWeakness_btn.Enabled = false;
            PokemonStrenght_pnl.Visible = false;
            PokemonWeakness_pnl.Visible = true;

            SetWeakness();
            SetPokemonNamesinClass();
            //Pokemon1[0] = new PokemonType();
            //Pokemon1[1] = new PokemonType();
            var Autocomplete = new AutoCompleteStringCollection();

            foreach (PokemonBase Pokemon in PokemonList)
            {
                PokemonList_combo.Items.Add(Pokemon.GetName());
                P2List_Combo.Items.Add(Pokemon.GetName());
                P3List_Combo.Items.Add(Pokemon.GetName());
                P4List_Combo.Items.Add(Pokemon.GetName());
                P5List_Combo.Items.Add(Pokemon.GetName());
                P6List_Combo.Items.Add(Pokemon.GetName());
                Autocomplete.Add(Pokemon.GetName());
            }

            PokemonList_combo.AutoCompleteCustomSource = Autocomplete;
            P2List_Combo.AutoCompleteCustomSource = Autocomplete;
            P3List_Combo.AutoCompleteCustomSource = Autocomplete;
            P4List_Combo.AutoCompleteCustomSource = Autocomplete;
            P5List_Combo.AutoCompleteCustomSource = Autocomplete;
            P6List_Combo.AutoCompleteCustomSource = Autocomplete;

            WeaknessGrid.RowHeadersVisible = false;
            WeaknessGrid.AllowUserToAddRows = false;
            WeaknessGrid.ColumnCount = 8;
            WeaknessGrid.Columns[0].Name = "Type";
            WeaknessGrid.Columns[1].Name = "Pokemon 1";
            WeaknessGrid.Columns[2].Name = "Pokemon 2";
            WeaknessGrid.Columns[3].Name = "Pokemon 3";
            WeaknessGrid.Columns[4].Name = "Pokemon 4";
            WeaknessGrid.Columns[5].Name = "Pokemon 5";
            WeaknessGrid.Columns[6].Name = "Pokemon 6";
            WeaknessGrid.Columns[7].Name = "Summary";

            MoveStrenght_grid.RowHeadersVisible = false;
            MoveStrenght_grid.AllowUserToAddRows = false;
            MoveStrenght_grid.ColumnCount = 19;
            MoveStrenght_grid.Columns[0].Name = "Type";
            MoveStrenght_grid.Columns[0].Width = MoveStrenght_grid.Width / 19;
            for (int i = 1; i < 19; i++)
            {
                MoveStrenght_grid.Columns[i].Name = ((PokeTypeSelection)(i-1)).ToString();
                MoveStrenght_grid.Columns[i].Width = MoveStrenght_grid.Width / 19;
            }

            for (int i = 0; i < 18; i++)
            {
                string[] Teststring1 = { ((PokeTypeSelection)i).ToString(), "1", "1", "1", "1", "1", "1", "1" };
                string[] Teststring2 = { ((PokeTypeSelection)i).ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                WeaknessGrid.Rows.Add(Teststring1);
                MoveStrenght_grid.Rows.Add(Teststring2);
                
            }

            chart1.Series[0].BorderColor = Color.Green;
            chart1.Series[0].Color = Color.Green;
        }

        private PokemonType SetPokemonType(int SelectedIndex)
        {
            PokemonType result = new PokemonType();

            switch (SelectedIndex)
            {
                case (int)PokeTypeSelection.Normal:
                    {
                        result = Normal;
                    } break;
                case (int)PokeTypeSelection.Fire:
                    {
                        result = Fire;
                    } break;
                case (int)PokeTypeSelection.Water:
                    {
                        result = Water;
                    } break;
                case (int)PokeTypeSelection.Electric:
                    {
                        result = Electric;
                    } break;
                case (int)PokeTypeSelection.Grass:
                    {
                        result = Grass;
                    } break;
                case (int)PokeTypeSelection.Ice:
                    {
                        result = Ice;
                    } break;
                case (int)PokeTypeSelection.Fighting:
                    {
                        result = Fighting;
                    } break;
                case (int)PokeTypeSelection.Poison:
                    {
                        result = Poison;
                    } break;
                case (int)PokeTypeSelection.Ground:
                    {
                        result = Ground;
                    } break;
                case (int)PokeTypeSelection.Flying:
                    {
                        result = Flying;
                    } break;
                case (int)PokeTypeSelection.Psychic:
                    {
                        result = Psychic;
                    } break;
                case (int)PokeTypeSelection.Bug:
                    {
                        result = Bug;
                    } break;
                case (int)PokeTypeSelection.Rock:
                    {
                        result = Rock;
                    } break;
                case (int)PokeTypeSelection.Ghost:
                    {
                        result = Ghost;
                    } break;
                case (int)PokeTypeSelection.Dragon:
                    {
                        result = Dragon;
                    } break;
                case (int)PokeTypeSelection.Dark:
                    {
                        result = Dark;
                    } break;
                case (int)PokeTypeSelection.Steel:
                    {
                        result = Steel;
                    } break;
                case (int)PokeTypeSelection.Fairy:
                    {
                        result = Fairy;
                    } break;
            }// end of switch case

            return result;
        }

        #region WeaknessComboboEvents
        private void Type1_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

            Pokemon1[0] = SetPokemonType(Type1_Combo.SelectedIndex);
            Pokemon1[1] = new PokemonType();
            Pokemon1Weak = CalculateWeaknessForPokemon(Pokemon1);
            UpdateWeaknessGridView();
        }

        private void Type2_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Type2_Combo.SelectedIndex == 0)
                Pokemon1[1] = new PokemonType();
            else
            {
                if (((Type2_Combo.SelectedIndex - 1) == Type1_Combo.SelectedIndex)
                        && Type1_Combo.SelectedIndex != -1)
                {
                    MessageBox.Show("Same type selected as type1, now that's abit silly no?", "Same typing");
                    Type2_Combo.SelectedIndex = -1;
                }
                else
                {
                    Pokemon1[1] = SetPokemonType(Type2_Combo.SelectedIndex - 1);                 
                }
            }
            Pokemon1Weak = CalculateWeaknessForPokemon(Pokemon1);
            UpdateWeaknessGridView();
        }

        private void PokemonList_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type1_Combo.SelectedIndex = (int)PokemonList[PokemonList_combo.SelectedIndex].GetPokemonType1();
            Type2_Combo.SelectedIndex = (int)PokemonList[PokemonList_combo.SelectedIndex].GetPokemonType2();
            P1_Ability_Combo.Items.Clear();
            P1_Ability_Combo.Items.AddRange(PokemonList[PokemonList_combo.SelectedIndex].GetAbilities().ToArray());
            P1_Ability_Combo.SelectedIndex = 0;
        }

        private void P2List_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            P2Type1_Combo.SelectedIndex = (int)PokemonList[P2List_Combo.SelectedIndex].GetPokemonType1();
            P2Type2_Combo.SelectedIndex = (int)PokemonList[P2List_Combo.SelectedIndex].GetPokemonType2();
            P2_Ability_Combo.Items.Clear();
            P2_Ability_Combo.Items.AddRange(PokemonList[P2List_Combo.SelectedIndex].GetAbilities().ToArray());
            P2_Ability_Combo.SelectedIndex = 0;
        }

        private void P2Type1_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pokemon2[0] = SetPokemonType(P2Type1_Combo.SelectedIndex);
            Pokemon2[1] = new PokemonType();
            Pokemon2Weak = CalculateWeaknessForPokemon(Pokemon2);
            UpdateWeaknessGridView();
        }

        private void P2Type2_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P2Type2_Combo.SelectedIndex == 0)
                Pokemon2[1] = new PokemonType();
            else
            {
                if (((P2Type2_Combo.SelectedIndex - 1) == P2Type1_Combo.SelectedIndex)
                        && P2Type1_Combo.SelectedIndex != -1)
                {
                    MessageBox.Show("Same type selected as type1, now that's abit silly no?", "Same typing");
                    P2Type2_Combo.SelectedIndex = -1;
                }
                else
                {
                    Pokemon2[1] = SetPokemonType(P2Type2_Combo.SelectedIndex - 1);
                }
            }
            Pokemon2Weak = CalculateWeaknessForPokemon(Pokemon2);
            UpdateWeaknessGridView();
        }

        private void WeaknessGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("cell changed");
        }

        private void P3Type1_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pokemon3[0] = SetPokemonType(P3Type1_Combo.SelectedIndex);
            Pokemon3[1] = new PokemonType();
            Pokemon3Weak = CalculateWeaknessForPokemon(Pokemon3);
            UpdateWeaknessGridView();
        }

        private void P3Type2_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P3Type2_Combo.SelectedIndex == 0)
                Pokemon3[1] = new PokemonType();
            else
            {
                if (((P3Type2_Combo.SelectedIndex - 1) == P3Type1_Combo.SelectedIndex)
                        && P3Type1_Combo.SelectedIndex != -1)
                {
                    MessageBox.Show("Same type selected as type1, now that's abit silly no?", "Same typing");
                    P3Type2_Combo.SelectedIndex = -1;
                }
                else
                {
                    Pokemon3[1] = SetPokemonType(P3Type2_Combo.SelectedIndex - 1);
                }
            }
            Pokemon3Weak = CalculateWeaknessForPokemon(Pokemon3);
            UpdateWeaknessGridView();
        }

        private void P3List_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            P3Type1_Combo.SelectedIndex = (int)PokemonList[P3List_Combo.SelectedIndex].GetPokemonType1();
            P3Type2_Combo.SelectedIndex = (int)PokemonList[P3List_Combo.SelectedIndex].GetPokemonType2();
            P3_Ability_Combo.Items.Clear();
            P3_Ability_Combo.Items.AddRange(PokemonList[P3List_Combo.SelectedIndex].GetAbilities().ToArray());
            P3_Ability_Combo.SelectedIndex = 0;
        }

        private void P4List_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            P4Type1_Combo.SelectedIndex = (int)PokemonList[P4List_Combo.SelectedIndex].GetPokemonType1();
            P4Type2_Combo.SelectedIndex = (int)PokemonList[P4List_Combo.SelectedIndex].GetPokemonType2();
            P4_Ability_Combo.Items.Clear();
            P4_Ability_Combo.Items.AddRange(PokemonList[P4List_Combo.SelectedIndex].GetAbilities().ToArray());
            P4_Ability_Combo.SelectedIndex = 0;
        }

        private void P4Type1_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pokemon4[0] = SetPokemonType(P4Type1_Combo.SelectedIndex);
            Pokemon4[1] = new PokemonType();
            Pokemon4Weak = CalculateWeaknessForPokemon(Pokemon4);
            UpdateWeaknessGridView();
        }

        private void P4Type2_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P4Type2_Combo.SelectedIndex == 0)
                Pokemon4[1] = new PokemonType();
            else
            {
                if (((P4Type2_Combo.SelectedIndex - 1) == P4Type1_Combo.SelectedIndex)
                        && P4Type1_Combo.SelectedIndex != -1)
                {
                    MessageBox.Show("Same type selected as type1, now that's abit silly no?", "Same typing");
                    P4Type2_Combo.SelectedIndex = -1;
                }
                else
                {
                    Pokemon4[1] = SetPokemonType(P4Type2_Combo.SelectedIndex - 1);
                }
            }
            Pokemon4Weak = CalculateWeaknessForPokemon(Pokemon4);
            UpdateWeaknessGridView();
        }

        private void P5List_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            P5Type1_Combo.SelectedIndex = (int)PokemonList[P5List_Combo.SelectedIndex].GetPokemonType1();
            P5Type2_Combo.SelectedIndex = (int)PokemonList[P5List_Combo.SelectedIndex].GetPokemonType2();
            P5_Ability_Combo.Items.Clear();
            P5_Ability_Combo.Items.AddRange(PokemonList[P5List_Combo.SelectedIndex].GetAbilities().ToArray());
            P5_Ability_Combo.SelectedIndex = 0;
        }

        private void P5Type1_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pokemon5[0] = SetPokemonType(P5Type1_Combo.SelectedIndex);
            Pokemon5[1] = new PokemonType();
            Pokemon5Weak = CalculateWeaknessForPokemon(Pokemon5);
            UpdateWeaknessGridView();
        }

        private void P5Type2_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P5Type2_Combo.SelectedIndex == 0)
                Pokemon5[1] = new PokemonType();
            else
            {
                if (((P5Type2_Combo.SelectedIndex - 1) == P5Type1_Combo.SelectedIndex)
                        && P5Type1_Combo.SelectedIndex != -1)
                {
                    MessageBox.Show("Same type selected as type1, now that's abit silly no?", "Same typing");
                    P5Type2_Combo.SelectedIndex = -1;
                }
                else
                {
                    Pokemon5[1] = SetPokemonType(P5Type2_Combo.SelectedIndex - 1);
                }
            }
            Pokemon5Weak = CalculateWeaknessForPokemon(Pokemon5);
            UpdateWeaknessGridView();
        }

        private void P6List_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            P6Type1_Combo.SelectedIndex = (int)PokemonList[P6List_Combo.SelectedIndex].GetPokemonType1();
            P6Type2_Combo.SelectedIndex = (int)PokemonList[P6List_Combo.SelectedIndex].GetPokemonType2();
            P6_Ability_Combo.Items.Clear();
            P6_Ability_Combo.Items.AddRange(PokemonList[P6List_Combo.SelectedIndex].GetAbilities().ToArray());
            P6_Ability_Combo.SelectedIndex = 0;
        }

        private void P6Type1_Combo_RightToLeftChanged(object sender, EventArgs e)
        {
            Pokemon6[0] = SetPokemonType(P6Type1_Combo.SelectedIndex);
            Pokemon6[1] = new PokemonType();
            Pokemon6Weak = CalculateWeaknessForPokemon(Pokemon6);
            UpdateWeaknessGridView();
        }

        private void P6Type2_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P6Type2_Combo.SelectedIndex == 0)
                Pokemon6[1] = new PokemonType();
            else
            {
                if (((P6Type2_Combo.SelectedIndex - 1) == P6Type1_Combo.SelectedIndex)
                        && P6Type1_Combo.SelectedIndex != -1)
                {
                    MessageBox.Show("Same type selected as type1, now that's abit silly no?", "Same typing");
                    P6Type2_Combo.SelectedIndex = -1;
                }
                else
                {
                    Pokemon6[1] = SetPokemonType(P6Type2_Combo.SelectedIndex - 1);
                }
            }
            Pokemon6Weak = CalculateWeaknessForPokemon(Pokemon6);
            UpdateWeaknessGridView();
        }

        private void P6Type1_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pokemon6[0] = SetPokemonType(P6Type1_Combo.SelectedIndex);
            Pokemon6[1] = new PokemonType();
            Pokemon6Weak = CalculateWeaknessForPokemon(Pokemon6);
            UpdateWeaknessGridView();
        }
        #endregion


        /// <summary>
        /// Makes the PokemonWeakness_pnl visible and the PokemonStrenght_pnl invisible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PokemonWeakness_btn_Click(object sender, EventArgs e)
        {
            PokemonWeakness_pnl.Visible = true;
            PokemonStrenght_pnl.Visible = false;
            PokemonWeakness_btn.Enabled = false;
            PokemonStrenght_btn.Enabled = true;
        }

        /// <summary>
        /// Makes the PokemonStrenght_pnl visible and the PokemonWeakness_pnl invisible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PokemonStrenght_btn_Click(object sender, EventArgs e)
        {
            PokemonWeakness_pnl.Visible = false;
            PokemonStrenght_pnl.Visible = true;
            PokemonWeakness_btn.Enabled = true;
            PokemonStrenght_btn.Enabled = false;
        }

        private void Normal_check_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStrengthGridView();
        }

        private void Fire_check_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStrengthGridView();
        }

        private void Prnt_button_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            Bitmap bm;
            string Savename = "";

            if (PokemonStrenght_btn.Enabled == true)
            {
                width = PokemonWeakness_pnl.Size.Width;
                height = PokemonWeakness_pnl.Size.Height;
                PokemonWeakness_pnl.BackColor = Color.White;
                bm = new Bitmap(width, height);
                PokemonWeakness_pnl.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                PokemonWeakness_pnl.BackColor = DefaultBackColor;
                Savename = "Weakness" + DateTime.Now.ToString("yyyyMMdd_HHmmss"); ;
            }
            else
            {
                width = PokemonStrenght_pnl.Size.Width;
                height = PokemonStrenght_pnl.Size.Height;
                PokemonStrenght_pnl.BackColor = Color.White;
                bm = new Bitmap(width, height);
                PokemonStrenght_pnl.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                PokemonStrenght_pnl.BackColor = DefaultBackColor;
                Savename = "Strength" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            }          

            bm.Save(Savename + ".png",System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Saved Image");
        }

        private void Ability_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(P1_Ability_Combo.SelectedIndex != -1)
                PokemonAbilities[0] = P1_Ability_Combo.SelectedItem.ToString();
            if (P2_Ability_Combo.SelectedIndex != -1)
                PokemonAbilities[1] = P2_Ability_Combo.SelectedItem.ToString();
            if (P3_Ability_Combo.SelectedIndex != -1)
                PokemonAbilities[2] = P3_Ability_Combo.SelectedItem.ToString();
            if (P4_Ability_Combo.SelectedIndex != -1)
                PokemonAbilities[3] = P4_Ability_Combo.SelectedItem.ToString();
            if (P5_Ability_Combo.SelectedIndex != -1)
                PokemonAbilities[4] = P5_Ability_Combo.SelectedItem.ToString();
            if (P6_Ability_Combo.SelectedIndex != -1)
                PokemonAbilities[5] = P6_Ability_Combo.SelectedItem.ToString();


            UpdateWeaknessGridView();
        }

    }

    /// <summary>
    /// Class to hold all the different pokemon types. 
    /// there will be 18 times this class (for each type)
    /// </summary>
    class PokemonType
    {
        // see it as variable attacks Pokemontype
        // 0 = immune, 1 = take normal damage, 2 = take double damage, 3 = take Resistant
        public int Normal;
        public int Fire;
        public int Water;
        public int Electric;
        public int Grass;
        public int Ice;
        public int Fighting;
        public int Poison;
        public int Ground;
        public int Flying;
        public int Psychic;
        public int Bug;
        public int Rock;
        public int Ghost;
        public int Dragon;
        public int Dark;
        public int Steel;
        public int Fairy;

        public PokemonType()
        {
            this.Normal = 1;
            this.Fire = 1;
            this.Water = 1;
            this.Electric = 1;
            this.Grass = 1;
            this.Ice = 1;
            this.Fighting = 1;
            this.Poison = 1;
            this.Ground = 1;
            this.Flying = 1;
            this.Psychic = 1;
            this.Bug = 1;
            this.Rock = 1;
            this.Ghost = 1;
            this.Dragon = 1;
            this.Dark = 1;
            this.Steel = 1;
            this.Fairy = 1;

        }
    };

    /// <summary>
    /// Class that holds the list off all known pokemon and their types
    /// </summary>
    class PokemonBase
    {
        int nationalID;
        string PokemonName;
        PokeTypeSelection Type1, Type2;
        string Ability1, Ability2, HiddenAbility;

        public PokemonBase()
        {
            nationalID = new int();
            PokemonName = "";
            Type1 = new PokeTypeSelection();
            Type2 = new PokeTypeSelection();
            Ability1 = "";
            Ability2 = "";
            HiddenAbility = "";
        }

        /// <summary>
        /// Add a pokemon with the provided parameters
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="AddType1"></param>
        /// <param name="AddType2"></param>
        /// <param name="AddAbility1"></param>
        /// <param name="AddAbility2"></param>
        /// <param name="AddHiddenAbility"></param>
        public PokemonBase(int ID, string Name, PokeTypeSelection AddType1, PokeTypeSelection AddType2, string AddAbility1,
                           string AddAbility2, string AddHiddenAbility)
        {
            nationalID = (ID);
            PokemonName = (Name);
            Type1 = AddType1;
            Type2 = AddType2;
            Ability1 = AddAbility1;
            Ability2 = AddAbility2;
            HiddenAbility = AddHiddenAbility;
        }

        /// <summary>
        /// returns the list containing the names
        /// </summary>
        /// <returns>List</returns>
        public string GetName()
        {
            return PokemonName;
        }

        /// <summary>
        /// returns ID associated with a PokeName
        /// </summary>
        /// <param name="PokeName"></param>
        /// <returns></returns>
        public int GetPokemonID()
        {
            return nationalID;
        }

        public PokeTypeSelection GetPokemonType1()
        {
            return Type1;
        }

        public PokeTypeSelection GetPokemonType2()
        {
            if (Type2 == PokeTypeSelection.None)
                return 0;
            else
                return (PokeTypeSelection)((int)Type2 + 1);
        }

        public string[] GetAbilities()
        {
            string[] returnstring = { Ability1, Ability2, HiddenAbility };
            return returnstring;
        }

    }
}

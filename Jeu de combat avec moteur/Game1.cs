using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jeu_de_combat_avec_moteur
{

    public class Game1 : Game
    {
        public static Entitees classJoueur = new Entitees();
        public static Entitees classIA = new Entitees();

        public static string tour = "joueur";


        public static int difficult = 5;
        public static int choixOpti = 0;
        public static int choixJoueur = 10;
        public static int choixClasseJoueur = 10;
        public static int choixIA = 0; 
        public static int choixClasseIA = 10;
        public static string nomClasseJoueur = "";
        public static string nomClasseIA = "";
        public static int nManche = 0;
        public static bool combatTermine = false;
        public static bool joueurDef = false;
        public static bool iADef = false;
        public static bool joueurTankSpe = false;
        public static bool joueurRangerSpe = false;
        public static int joueurRangerCharge = 1;
        public static int iaRangerCharge = 1;
        public static bool iaTankSpe = false;
        public static bool iaRangerSpe = false;
        public static bool joueurDmgSpe = false;
        public static bool iaDmgSpe = false;
        public static string resolutionJoueur = "";
        public static string resolutionIA = "";
        public static string winner = "";
        public static bool active_audio = false;
        public static bool control_slider = false;


        bool song_playing = false;


        Texture2D button_start;
        Texture2D classe1Texture;
        Texture2D classe2Texture;
        Texture2D classe3Texture;
        Texture2D classe4Texture;

        Texture2D sprite_classe1Texture;
        Texture2D sprite_classe2Texture;
        Texture2D sprite_classe3Texture;
        Texture2D sprite_classe4Texture;
        Texture2D sprite_classe1Texture_IA;
        Texture2D sprite_classe2Texture_IA;
        Texture2D sprite_classe3Texture_IA;
        Texture2D sprite_classe4Texture_IA;


        Texture2D boutton_att;
        Texture2D kirbyTexture;
        Texture2D attackTexture;
        Texture2D healthTexture;
        Texture2D ui_fight;

        Texture2D attack_boutton;
        Texture2D defense_boutton;
        Texture2D spe_boutton_heal;
        Texture2D spe_boutton_dmg;
        Texture2D spe_boutton_ranger;
        Texture2D spe_boutton_tank;

        Texture2D slider_button;
        Texture2D slider_barre;

        Texture2D bg_combat;
        Texture2D bg_diff_10;
        Texture2D bg_ecrand_de_fin;
        Texture2D bg_selec_perso;
        Texture2D bg_start;

        SoundEffectInstance selection_song;
        SoundEffectInstance fight_song;
        

        List<Texture2D> list_boutton_texture_selec;
        List<System.Numerics.Vector2> list_boutton_pos_selec;
        List<Texture2D> list_sprite;
        List<Texture2D> list_boutton_combat_texture;
        List<System.Numerics.Vector2> list_boutton_combat_pos;


        private SpriteFont font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        string screen = "menu";
        bool testpress = false;


        System.Numerics.Vector2 boutton_start_taille = new System.Numerics.Vector2(250, 250);
        System.Numerics.Vector2 boutton_taille = new System.Numerics.Vector2(250,250);
        System.Numerics.Vector2 boutton_action_taille = new System.Numerics.Vector2(100,100);
        System.Numerics.Vector2 slider_button_taille = new System.Numerics.Vector2(117, 117);
        System.Numerics.Vector2 slider_barre_taille = new System.Numerics.Vector2(850,48);

        System.Numerics.Vector2 boutton_start_pos = new System.Numerics.Vector2(450,100);
        System.Numerics.Vector2 boutton1_pos = new System.Numerics.Vector2(40,150);
        System.Numerics.Vector2 boutton2_pos = new System.Numerics.Vector2(290,150);
        System.Numerics.Vector2 boutton3_pos = new System.Numerics.Vector2(540,150);
        System.Numerics.Vector2 boutton4_pos = new System.Numerics.Vector2(790,150);
        System.Numerics.Vector2 boutton_attack_pos = new System.Numerics.Vector2(40,600);
        System.Numerics.Vector2 boutton_defense_pos = new System.Numerics.Vector2(160,600);
        System.Numerics.Vector2 boutton_spe_pos = new System.Numerics.Vector2(280, 600);

        System.Numerics.Vector2 slider_button_pos = new System.Numerics.Vector2(100, 515);
        System.Numerics.Vector2 slider_barre_pos = new System.Numerics.Vector2(100, 520);

        System.Numerics.Vector2 sprite_joueur_pos = new System.Numerics.Vector2(50,170);
        System.Numerics.Vector2 sprite_IA_pos = new System.Numerics.Vector2(720,170);

        System.Numerics.Vector2 mousePos = new System.Numerics.Vector2(0, 0);


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1080;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Charge tout les assets qui vont être utilisé
            button_start = Content.Load<Texture2D>("button Start");
            classe1Texture = Content.Load<Texture2D>("bouton Choix Damager");
            classe2Texture = Content.Load<Texture2D>("bouton Choix Healer");
            classe3Texture = Content.Load<Texture2D>("bouton Choix Tank");
            classe4Texture = Content.Load<Texture2D>("bouton Choix Ranger");

            sprite_classe1Texture = Content.Load<Texture2D>("damager gauche");
            sprite_classe2Texture = Content.Load<Texture2D>("healer gauche");
            sprite_classe3Texture = Content.Load<Texture2D>("tank gauche");
            sprite_classe4Texture = Content.Load<Texture2D>("ranger gauche");
            sprite_classe1Texture_IA = Content.Load<Texture2D>("damager droite");
            sprite_classe2Texture_IA = Content.Load<Texture2D>("healer droite");
            sprite_classe3Texture_IA = Content.Load<Texture2D>("tank droite");
            sprite_classe4Texture_IA = Content.Load<Texture2D>("ranger droite");

            boutton_att = Content.Load<Texture2D>("boutton_select");
            attackTexture = Content.Load<Texture2D>("attack");
            healthTexture = Content.Load<Texture2D>("Coeur full");
            ui_fight = Content.Load<Texture2D>("ui fight");

            attack_boutton = Content.Load<Texture2D>("Boutton Atk gb");
            defense_boutton = Content.Load<Texture2D>("btn def gb");
            spe_boutton_heal = Content.Load<Texture2D>("btn spell gb");
            spe_boutton_dmg = Content.Load<Texture2D>("btn spell gb");
            spe_boutton_ranger = Content.Load<Texture2D>("btn spell gb");
            spe_boutton_tank = Content.Load<Texture2D>("btn spell gb");

            slider_barre = Content.Load<Texture2D>("Slider barre");
            slider_button = Content.Load<Texture2D>("Slider button");

            bg_combat = Content.Load<Texture2D>("bg combat");
            bg_diff_10 = Content.Load<Texture2D>("bg diff 10");
            bg_ecrand_de_fin = Content.Load<Texture2D>("bg ecran de fin");
            bg_selec_perso = Content.Load<Texture2D>("bg choix persos");
            bg_start = Content.Load<Texture2D>("bg start");

            // Permet de vérifier qu'il y a bien un periférique audio branché
            try
            {
                selection_song = Content.Load<SoundEffect>("select_song").CreateInstance();
                fight_song = Content.Load<SoundEffect>("Musique_jeu_de_combat").CreateInstance();

            }
            catch
            {
                active_audio = false;
            }

            // Met les textures et les position des boutton et des sprites dans des listes 
            list_boutton_texture_selec = new List<Texture2D>() { classe1Texture, classe2Texture, classe3Texture, classe4Texture };
            list_boutton_pos_selec = new List<System.Numerics.Vector2>() { boutton1_pos, boutton2_pos, boutton3_pos, boutton4_pos };
            list_sprite = new List<Texture2D>() { sprite_classe1Texture, sprite_classe2Texture, sprite_classe3Texture, sprite_classe4Texture, sprite_classe1Texture_IA , sprite_classe2Texture_IA , sprite_classe3Texture_IA , sprite_classe4Texture_IA };

            list_boutton_combat_texture = new List<Texture2D>() {attack_boutton, defense_boutton,spe_boutton_dmg, spe_boutton_heal,spe_boutton_tank,spe_boutton_ranger};
            list_boutton_combat_pos = new List<System.Numerics.Vector2>() { boutton_attack_pos,boutton_defense_pos,boutton_spe_pos};

        }

        // Début de la fonction Update qui se répéte en boucle (c'est ici qu'est gérée tout la partie fonctionnnel du jeu) 
        protected override void Update(GameTime gameTime)
        {
            // Permet d'avoir en mémoire tout les input fait par le joueur
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                     Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var kstate = Keyboard.GetState();
            MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            mousePos.X = mouseState.X;
            mousePos.Y = mouseState.Y;

            // Code à executer si l'on se trouve dans l'écran de menu
            if (screen == "menu")
            {
                // Permet de gérer le slider
                if (slider_button_pos.X < mousePos.X + 1 && slider_button_pos.X + slider_button_taille.X > mousePos.X && slider_button_pos.Y < mousePos.Y + 1 && slider_button_pos.Y + slider_button_taille.Y > mousePos.Y && mouseState.LeftButton == ButtonState.Pressed)
                {
                    control_slider = true;
                }
                if (mouseState.LeftButton == ButtonState.Released)
                {
                    control_slider = false;
                }
                if (control_slider) 
                {
                    if (mousePos.X - 50 < slider_barre_pos.X)
                    {
                        slider_button_pos.X = slider_barre_pos.X;
                    }
                    else if (mousePos.X - 50 > slider_barre_pos.X + slider_barre_taille.X - slider_button_taille.X)
                    {
                        slider_button_pos.X = slider_barre_pos.X + slider_barre_taille.X - slider_button_taille.X;
                    }
                    else
                    {
                        slider_button_pos.X = mousePos.X - 50;
                    }
                }
                // Change la difficultée en fonction du slider
                difficult = (Convert.ToInt32(slider_button_pos.X) - 100)/73;

                // Permet de passé à l'écran de selection de personnage si le boutton start est appuyé
                if (boutton_start_pos.X < mousePos.X + 1 && boutton_start_pos.X + boutton_start_taille.X > mousePos.X && boutton_start_pos.Y < mousePos.Y + 1 && boutton_start_pos.Y + boutton_start_taille.Y > mousePos.Y && mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = "selec";
                }



            }
            // Code à executer si l'on se trouve dans l'écran de selection de personnage
            else if (screen == "selec")
            {
                // Lance la musique
                if (!song_playing && active_audio)
                {
                    selection_song.Play();
                    song_playing = true;
                    selection_song.IsLooped = true;
                }

                // Verifie si on appuie sur un boutton de selection de classe
                int compte = 0;
                foreach (var b_pos in list_boutton_pos_selec)
                {
                    if (b_pos.X < mousePos.X + 1 && b_pos.X + boutton_taille.X > mousePos.X && b_pos.Y < mousePos.Y + 1 && b_pos.Y + boutton_taille.Y > mousePos.Y && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        choixClasseJoueur = compte;
                    }
                    compte++;
                }

                // Assigne le choix du joueur à une classe spécifique
                if (choixClasseJoueur != 10)
                {
                    switch (choixClasseJoueur)
                    {
                        case 0:
                            classJoueur = new Entitees.Damager();
                            nomClasseJoueur = "Damager";
                            break;
                        case 1:
                            nomClasseJoueur = "Healer";
                            classJoueur = new Entitees.Healer();
                            break;
                        case 2:
                            nomClasseJoueur = "Tank";
                            classJoueur = new Entitees.Tank();
                            break;
                        case 3:
                            nomClasseJoueur = "Ranger";
                            classJoueur = new Entitees.Ranger();
                            break;
                    }
                    classJoueur.hprestants = classJoueur.hp;
                    screen = "game";
                    selection_song.Stop();
                    song_playing = false;
                    // Fait choisir une classe aléatoirement par l'IA
                    ChoixIA();
                }

            }
            // Code à executer si l'on se trouve dans l'écran de jeu
            else if (screen == "game")
            {
                // Lance la musique
                if (!song_playing && active_audio)
                {
                    fight_song.Play();
                    song_playing = true;
                    fight_song.IsLooped = true;
                }
                // Tour du joueur
                if (tour == "joueur")
                {
                    //Reset global des variables
                    resolutionJoueur = "";
                    joueurDef = false; //reset de la parade 
                    classJoueur.hpPerdus = 0;
                    joueurDmgSpe = false;
                    if (joueurTankSpe) //on reset l'etat et l'att si le tank a utilisé son spell
                    {
                        classJoueur.att--;
                        joueurTankSpe = false;
                    }

                    //Verifie si un boutton d'action est appuyé
                    int compte = 0;
                    foreach (var b_pos in list_boutton_combat_pos)
                    {
                        if (b_pos.X < mousePos.X + 1 && b_pos.X + boutton_action_taille.X > mousePos.X && b_pos.Y < mousePos.Y + 1 && b_pos.Y + boutton_action_taille.Y > mousePos.Y && mouseState.LeftButton == ButtonState.Pressed)
                        {
                            choixJoueur = compte + 1;
                            nManche++;
                        }
                        compte++;
                    }
                    if (choixJoueur != 10)
                    {
                        switch (choixJoueur)
                        {
                            case 1:
                                if (!iADef) //on verifie si l'ia se défends
                                {
                                    classIA.hprestants -= classJoueur.att;
                                    classIA.hpPerdus = classJoueur.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                    resolutionJoueur = "Votre coup a touché ! L'adversaire a perdu " + classJoueur.att.ToString() + " point(s) de vie";
                                }
                                else
                                {
                                    resolutionJoueur = "D'un geste habile, votre adversaire pare le coup, il ne perds pas de points de vie";
                                }
                                break;
                            case 2:
                                joueurDef = true;
                                resolutionJoueur = "Vous tentez de bloquer !";
                                break;

                            case 3:
                                classJoueur.speAtt();

                                if (nomClasseJoueur == "Damager")
                                { joueurDmgSpe = true; }
                                else if (nomClasseJoueur == "Tank")
                                { joueurTankSpe = true; }
                                else if (nomClasseJoueur == "Ranger")
                                {
                                    if (joueurRangerCharge >= 2)
                                    {
                                        joueurRangerSpe = true;
                                        joueurRangerCharge = 1;
                                    }
                                    else
                                    {
                                        joueurRangerCharge += 1;
                                        resolutionJoueur = "Vous prenez le temps d'ajuster votre flèche...";
                                    }
                                }
                                if (joueurTankSpe) //si le joueur est tank ET a lancé son att spe, on lance une attaque apres le buff stat
                                {
                                    if (!iADef) //on verifie si l'ia ne se défends pas
                                    {
                                        classIA.hprestants -= classJoueur.att;
                                        classIA.hpPerdus = classJoueur.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                        resolutionJoueur = "Vous mettez toute votre rage dans ce coup, cela vous fait perdre 1 point de vie cependant, votre adversaire a perdu " + classJoueur.att.ToString() + " point(s) de vie";
                                    }
                                    else if (joueurTankSpe) //on vérifie si le spell du tank est actif, si oui on ne pare qu'1 point de dégat
                                    {
                                        classIA.hprestants -= classJoueur.att - 1;
                                        resolutionJoueur = "En sacrifiant 1 point de vie, vous réussissez a traverser la parade de votre adversaire ! Il a perdu " + (classJoueur.att - 1).ToString() + " point(s) de vie.";
                                    }
                                }
                                else if (joueurRangerSpe)
                                {
                                    if (!iADef) //on verifie si l'ia ne se défends pas
                                    {
                                        classIA.hprestants -= 5;
                                        classIA.hpPerdus = 5;
                                        resolutionJoueur = "Votre tir est tellement puissant que vous tombez en arriere, votre adversaire prend votre flèche en pleine poirtine, il perd 5 points de vie";
                                    }
                                    else
                                    {
                                        classIA.hprestants -= 5;
                                        resolutionJoueur = "Vous tirez votre flèche, votre adversaire tente de la dervier, sans succes, il perd 5 points de vie";
                                    }
                                }
                                break;
                        }
                        choixJoueur = 10;
                        tour = "IA";
                    }
                }
                // Tour de l'IA
                else if (tour == "IA")
                {
                    Thread.Sleep(800);
                    iADef = false; //reset de la parade
                    choixIA = 0;
                    classIA.hpPerdus = 0;
                    iaDmgSpe = false;
                    if (iaTankSpe) //on reset l'etat et l'att si le tank a utilisé son spell
                    {
                        classIA.att--;
                        iaTankSpe = false;
                    }

                    // Choisi si le choix de l'IA sera optimisée en fonction de la difficutlé
                    Random rand = new Random();
                    choixOpti = rand.Next(difficult, 15);

                    // L'IA choisi son action en fonction de sa classe et de si son choix est optimisé
                    if (nomClasseIA == "Damager")
                    {
                        if (choixOpti >= 10)
                        {
                            choixIA = 1;
                        }
                        else
                        {
                            choixIA = rand.Next(1, 4);
                        }
                    }
                    else if (nomClasseIA == "Healer")
                    {
                        if (choixOpti >= 10)
                        {
                            if (classIA.hprestants <= 2)
                            {
                                choixIA = 3;
                            }
                            else
                            {
                                choixIA = 1;
                            }
                        }
                        else
                        {
                            choixIA = rand.Next(1, 4);
                        }
                    }
                    else if (nomClasseIA == "Tank")
                    {
                        if (choixOpti >= 10)
                        {
                            if (classIA.hprestants >= 2)
                            {
                                choixIA = 3;
                            }
                            else
                            {
                                choixIA = 1;
                            }
                        }
                        else
                        {
                            choixIA = rand.Next(1, 4);
                        }
                    }
                    else if (nomClasseIA == "Ranger")
                    {
                        if (choixOpti >= 10)
                        {
                            if (classIA.hprestants >= 2)
                            {
                                choixIA = 3;
                            }
                            else if (iaRangerCharge == 2)
                            {
                                choixIA = 3;
                            }
                            else
                            {
                                choixIA = 1;
                            }
                        }
                        else
                        {
                            choixIA = rand.Next(1, 4);
                        }
                    }

                    // L'IA joue son tour
                    if (choixIA == 2)
                    {
                        iADef = true;
                    }
                    switch (choixIA)
                    {
                        case 1:
                            if (!joueurDef) //on verifie si le joueur se défends
                            {
                                classJoueur.hprestants -= classIA.att;
                                classJoueur.hpPerdus = classIA.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                resolutionIA = "L'adversaire vous a asséné un coup ! Vous perdez " + classIA.att.ToString() + " point(s) de vie...";
                            }
                            else
                            {
                                resolutionIA = "Vous parez le coup grâce a une roulade bien timée";
                            }
                            break;

                        case 2:
                            resolutionIA = "L'adversaire tente de se défendre...";
                            break;

                        case 3:
                            classIA.speAtt();
                            if (nomClasseIA == "Damager")
                            { iaDmgSpe = true; }
                            if (nomClasseIA == "Tank")
                            { iaTankSpe = true; }
                            else if (nomClasseIA == "Ranger")
                                if (iaRangerCharge >= 2)
                                {
                                    iaRangerSpe = true;
                                    iaRangerCharge = 1;
                                }
                                else
                                    iaRangerCharge += 1;
                            resolutionIA = "Votre adversaire prends le temps d'ajuster son tir...";
                            if (iaTankSpe)
                            {
                                if (!joueurDef) //on verifie si le joueur se défends
                                {
                                    classJoueur.hprestants -= classIA.att;
                                    classJoueur.hpPerdus = classIA.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                    resolutionIA = "L'adversaire vous a asséné un coup puissant ! Grâce à son sacrifice de 1 point de vie, vous perdez " + classIA.att.ToString() + " point(s) de vie...";
                                }
                                else if (iaTankSpe) //on vérifie si le spell du tank est actif, si oui on ne pare qu'1 point de dégat
                                {
                                    classJoueur.hprestants -= classIA.att - 1;
                                    resolutionIA = "Votre adversaire enrage et perd 1 point de vie, grâce a cela, il traverse votre parade et vous perdez " + classIA.att.ToString() + " point(s) de vie...";
                                }
                            }
                            else if (iaRangerSpe)
                            {
                                if (!joueurDef) //on verifie si l'ia ne se défends pas
                                {
                                    classJoueur.hprestants -= 5;
                                    classJoueur.hpPerdus = 5; //on stock l'info pour le renvoi (on reset a chaque tour)
                                    resolutionIA = "La fleche de votre adversaire vous traverse de part en part, vous perdez 5 points de vie";
                                }
                                else
                                {
                                    classJoueur.hprestants -= 5;
                                    resolutionIA = "Vous tentez de parer la fleche tirée par votre adversaire, malheureusement elle est trop puissante et déchire votre armure, vous perdez 5 points de vie";
                                }
                            }
                            break;
                    }

                    if (joueurDmgSpe)
                    {
                        classIA.hprestants -= classJoueur.hpPerdus; //active le renvoie des damages, a bien relier dans la resolution de l'ia
                        resolutionJoueur += " Vous contre-attaquez et il perd " + classIA.hpPerdus + " point(s) de vie";
                    }

                    if (iaDmgSpe)
                    {
                        classJoueur.hprestants -= classIA.hpPerdus; //active le renvoie des damages, a bien relier dans la resolution de l'ia
                        resolutionIA += " Malheureusement vous prenez une contre attaque désesperée et perdez " + classJoueur.hpPerdus + "point(s) de vie";
                    }
                    tour = "joueur";
                }

                // Vérifie si un des deux joueurs n'a plus de HP
                if (classJoueur.hprestants <= 0)
                {
                    winner = "ia";
                    screen = "end";
                }
                if (classIA.hprestants <= 0)
                {
                    winner = "joueur";
                    screen = "end";
                }
            }
            // Code à executer si l'on se trouve dans l'écran de fin
            else if (screen == "end") 
            { 

            }


            base.Update(gameTime);
        }

        // Début de la fonction Draw qui se répéte en boucle (c'est ici qu'est gérée tout la partie graphique du jeu) 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            font = Content.Load<SpriteFont>("Text");

            // Affiche les graphisme à l'écran en fonction de quelle écran doit être affiché 
            if (screen == "menu")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(bg_start, new System.Numerics.Vector2(0, 0), Color.White);
                _spriteBatch.Draw(slider_barre,slider_barre_pos, Color.White);
                _spriteBatch.Draw(slider_button,slider_button_pos, Color.White);
                _spriteBatch.Draw(slider_button, slider_button_pos, Color.White);
                _spriteBatch.Draw(button_start, boutton_start_pos, Color.White);
                _spriteBatch.End();

            }
            else if (screen == "selec")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(bg_selec_perso, new System.Numerics.Vector2(0, 0), Color.White);
                _spriteBatch.Draw(list_boutton_texture_selec[0], list_boutton_pos_selec[0], Color.White);
                _spriteBatch.Draw(list_boutton_texture_selec[1], list_boutton_pos_selec[1], Color.White);
                _spriteBatch.Draw(list_boutton_texture_selec[2], list_boutton_pos_selec[2], Color.White);
                _spriteBatch.Draw(list_boutton_texture_selec[3], list_boutton_pos_selec[3], Color.White);
                _spriteBatch.End();
            }
            else if (screen == "game")
            {
                _spriteBatch.Begin();
                if (difficult == 10)
                {
                    _spriteBatch.Draw(bg_diff_10, new System.Numerics.Vector2(0, 0), Color.White);
                }
                else
                {
                    _spriteBatch.Draw(bg_combat, new System.Numerics.Vector2(0, 0), Color.White); 
                }
                _spriteBatch.End();

                for (int i = 0; i < classJoueur.hprestants; i++)
                {
                    System.Numerics.Vector2 positionProvi1 = sprite_joueur_pos;

                    positionProvi1.X += (i * 90);
                    positionProvi1.Y -= 70;

                    _spriteBatch.Begin();
                    _spriteBatch.Draw(healthTexture,positionProvi1, Color.White);
                    _spriteBatch.End();
                }
                for (int i = 0; i < classJoueur.att; i++)
                {
                    System.Numerics.Vector2 positionProvi2 = sprite_joueur_pos;
                    positionProvi2.X += i * 40;
                    positionProvi2.Y += 390;
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(attackTexture, positionProvi2, Color.White);
                    _spriteBatch.End();
                }
                for (int i = 0; i < classIA.hprestants; i++)
                {
                    System.Numerics.Vector2 positionProvi1 = sprite_IA_pos;

                    positionProvi1.X += (i * 90);
                    positionProvi1.Y -= 70;
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(healthTexture, positionProvi1, Color.White);
                    _spriteBatch.End();
                }
                for (int i = 0; i < classIA.att; i++)
                {
                    System.Numerics.Vector2 positionProvi2 = sprite_IA_pos;
                    positionProvi2.X += i * 40;
                    positionProvi2.Y += 390;
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(attackTexture, positionProvi2, Color.White);
                    _spriteBatch.End();
                }

                _spriteBatch.Begin();
                _spriteBatch.Draw(list_sprite[choixClasseJoueur], sprite_joueur_pos, Color.White);
                _spriteBatch.Draw(list_sprite[choixClasseIA+4], sprite_IA_pos, Color.White);
                _spriteBatch.Draw(ui_fight, new System.Numerics.Vector2(0, 580), Color.White);
                _spriteBatch.Draw(list_boutton_combat_texture[0], list_boutton_combat_pos[0], Color.White);
                _spriteBatch.Draw(list_boutton_combat_texture[1], list_boutton_combat_pos[1], Color.White);
                _spriteBatch.Draw(list_boutton_combat_texture[2+choixClasseJoueur], list_boutton_combat_pos[2], Color.White);
                _spriteBatch.End();
            }
            else if (screen == "end")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(bg_ecrand_de_fin, new System.Numerics.Vector2(0, 0), Color.White);
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }
        public static void ChoixIA() //Cette fonction permet de choisir la Classe de l'IA
        {
            Random rand = new Random();
            choixClasseIA = rand.Next(0, 4);
            switch (choixClasseIA)
            {
                case 0:
                    classIA = new Entitees.Damager();
                    nomClasseIA = "Damager";
                    break;

                case 1:
                    nomClasseIA = "Healer";
                    classIA = new Entitees.Healer();
                    break;

                case 2:
                    nomClasseIA = "Tank";
                    classIA = new Entitees.Tank();
                    break;
                case 3:
                    nomClasseIA = "Ranger";
                    classIA = new Entitees.Ranger();
                    break;
            }
            classIA.hprestants = classIA.hp;
        }

    }


    // Class
    public class Entitees
    {
        public int hprestants;
        public int hp;
        public int hpPerdus = 0;
        public int att = 1;
        public string descSpell = "";
        public virtual void speAtt()
        { }

        public class Damager : Entitees
        {
            public override void speAtt()
            {
                Game1.joueurDmgSpe = true;
            }
            public Damager()
            {
                hp = 3;
                att = 2;
                descSpell = "Répliquer les dégats subis ce tour (ne vous protege pas des dégats)";
            }
        }

        public class Healer : Entitees
        {
            public override void speAtt()
            {
                //les conditions verifient et limitent le gain de hp aux hpmax
                if (hprestants + 2 <= hp)
                { hprestants += 2; }
                else if (hprestants + 1 == hp)
                { hprestants++; }
                else { Console.WriteLine(" Les points de vie sont au maximum, le sort n'a pas eu d'effet"); }
            }
            public Healer()
            {
                hp = 4;
                descSpell = "Regagner 2 points de vie";
            }
        }
        public class Tank : Entitees
        {
            public override void speAtt()
            {
                hprestants--;
                att++;
            }
            public Tank()
            {
                hp = 5;
                descSpell = "Sacrifier 1 point de vie pour gagner 1 point de dégats pour ce tour puis attaquer";
            }
        }
        public class Ranger : Entitees
        {
            public override void speAtt()
            {
                ;
            }
            public Ranger()
            {
                hp = 3;
                att = 2;
                descSpell = "2 tours pour charger une attaque qui inflige 5 damages";
            }
        }
    }
}

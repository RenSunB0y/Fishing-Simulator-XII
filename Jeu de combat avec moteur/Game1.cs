using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

// 104100
// 295500
// 5E8549
// D4D29B

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
        public static string nomClasseJoueur = " ";
        public static string nomClasseIA = " ";
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
        public static string resolutionJoueur = " ";
        public static string resolutionIA = " ";
        public static string winner = "  ";
        public static bool active_audio = false;
        public static bool control_slider = false;
        public static bool verif_hp = false;

        public static int anim_frame = 0;
        public static string animation_en_cour = "non";
        public static int anim_time = 0;
        public static string animation_sur = "  ";


        bool song_playing = false;


        Texture2D button_play;
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

        Texture2D hit_effect_1;
        Texture2D hit_effect_2;
        Texture2D hit_effect_3;
        Texture2D def_effect;
        Texture2D arrow;
        Texture2D flash;
        Texture2D eyes_joueur;
        Texture2D eyes_IA;

        Texture2D boutton_att;
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
        List<Texture2D> list_animation;


        private SpriteFont font;
        private SpriteFont endFont;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        string screen = "menu";



        System.Numerics.Vector2 boutton_start_taille = new System.Numerics.Vector2(270, 108);
        System.Numerics.Vector2 boutton_taille = new System.Numerics.Vector2(250, 250);
        System.Numerics.Vector2 boutton_action_taille = new System.Numerics.Vector2(100, 100);
        System.Numerics.Vector2 slider_button_taille = new System.Numerics.Vector2(117, 117);
        System.Numerics.Vector2 slider_barre_taille = new System.Numerics.Vector2(850, 48);

        System.Numerics.Vector2 boutton_start_pos = new System.Numerics.Vector2(405, 50);
        System.Numerics.Vector2 boutton1_pos = new System.Numerics.Vector2(40, 150);
        System.Numerics.Vector2 boutton2_pos = new System.Numerics.Vector2(290, 150);
        System.Numerics.Vector2 boutton3_pos = new System.Numerics.Vector2(540, 150);
        System.Numerics.Vector2 boutton4_pos = new System.Numerics.Vector2(790, 150);
        System.Numerics.Vector2 boutton_attack_pos = new System.Numerics.Vector2(40, 600);
        System.Numerics.Vector2 boutton_defense_pos = new System.Numerics.Vector2(160, 600);
        System.Numerics.Vector2 boutton_spe_pos = new System.Numerics.Vector2(280, 600);

        System.Numerics.Vector2 slider_button_pos = new System.Numerics.Vector2(100, 515);
        System.Numerics.Vector2 slider_barre_pos = new System.Numerics.Vector2(100, 520);

        System.Numerics.Vector2 sprite_joueur_pos = new System.Numerics.Vector2(50, 170);
        System.Numerics.Vector2 sprite_IA_pos = new System.Numerics.Vector2(720, 170);

        System.Numerics.Vector2 mousePos = new System.Numerics.Vector2(0, 0);

        System.Numerics.Vector2 textbox = new System.Numerics.Vector2(390, 605);
        System.Numerics.Vector2 textbox2 = new System.Numerics.Vector2(390, 655);
        System.Numerics.Vector2 endTextPos = new System.Numerics.Vector2(250, 160);



        System.Numerics.Vector2 animation_origine_pos;
        System.Numerics.Vector2 animation_pos;


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

            // Charge tout les assets qui vont etre utilise
            button_play = Content.Load<Texture2D>("play");
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

            hit_effect_1 = Content.Load<Texture2D>("effect hit 1");
            hit_effect_2 = Content.Load<Texture2D>("effect hit 2");
            hit_effect_3 = Content.Load<Texture2D>("effect hit 3");
            def_effect = Content.Load<Texture2D>("anim def");
            arrow = Content.Load<Texture2D>("arrow");
            flash = Content.Load<Texture2D>("flash");
            eyes_joueur = Content.Load<Texture2D>("eyes joueur");
            eyes_IA = Content.Load<Texture2D>("eyes IA");

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

            font = Content.Load<SpriteFont>("Font");
            endFont = Content.Load<SpriteFont>("EndFont");
            // Permet de verifier qu'il y a bien un periferique audio branche
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
            list_sprite = new List<Texture2D>() { sprite_classe1Texture, sprite_classe2Texture, sprite_classe3Texture, sprite_classe4Texture, sprite_classe1Texture_IA, sprite_classe2Texture_IA, sprite_classe3Texture_IA, sprite_classe4Texture_IA };

            list_boutton_combat_texture = new List<Texture2D>() { attack_boutton, defense_boutton, spe_boutton_dmg, spe_boutton_heal, spe_boutton_tank, spe_boutton_ranger };
            list_boutton_combat_pos = new List<System.Numerics.Vector2>() { boutton_attack_pos, boutton_defense_pos, boutton_spe_pos };

            list_animation = new List<Texture2D>() { hit_effect_1, hit_effect_2, hit_effect_3 };


        }

        // Debut de la fonction Update qui se repete en boucle (c'est ici qu'est geree tout la partie fonctionnnel du jeu) 
        protected override void Update(GameTime gameTime)
        {

            if (animation_en_cour == "non")
            {
                // Permet d'avoir en memoire tout les input fait par le joueur
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                         Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                var kstate = Keyboard.GetState();
                MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
                mousePos.X = mouseState.X;
                mousePos.Y = mouseState.Y;

                // Code a executer si l'on se trouve dans l'ecran de menu
                if (screen == "menu")
                {

                    // Permet de gerer le slider
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
                    // Change la difficultee en fonction du slider
                    difficult = (Convert.ToInt32(slider_button_pos.X) - 100) / 73;



                    // Permet de passe a l'ecran de selection de personnage si le boutton start est appuye
                    if (boutton_start_pos.X < mousePos.X + 1 && boutton_start_pos.X + boutton_start_taille.X > mousePos.X && boutton_start_pos.Y < mousePos.Y + 1 && boutton_start_pos.Y + boutton_start_taille.Y > mousePos.Y && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        screen = "selec";
                    }

                }
                // Code a executer si l'on se trouve dans l'ecran de selection de personnage
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

                    // Assigne le choix du joueur a une classe specifique
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
                        // Fait choisir une classe aleatoirement par l'IA
                        ChoixIA();
                    }

                }
                // Code a executer si l'on se trouve dans l'ecran de jeu
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
                            //On initialise le tour : choix du joueur ET de l'ia pour faciliter les interactions.
                        //Reset global des variables
                        joueurDef = false; //reset de la parade 
                        classJoueur.hpPerdus = 0;
                        joueurDmgSpe = false;

                        iADef = false; //reset de la parade
                        choixIA = 0;
                        classIA.hpPerdus = 0;
                        iaDmgSpe = false;

                        if (iaTankSpe) //on reset l'etat et l'att si le tank a utilise son spell
                        {
                            classIA.att--;
                            iaTankSpe = false;
                        }

                        // Choisi si le choix de l'IA sera optimisee en fonction de la difficutle
                        Random rand = new Random();
                        choixOpti = rand.Next(difficult, 15);

                        // L'IA choisi son action en fonction de sa classe et de si son choix est optimise
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

                        if (choixIA == 2)
                        {
                            iADef = true;
                        }

                        if (joueurTankSpe) //on reset l'etat et l'att si le tank a utilise son spell
                        {
                            classJoueur.att--;
                            joueurTankSpe = false;
                        }

                        //Verifie si un boutton d'action est appuye
                        int compte = 0;
                        foreach (var b_pos in list_boutton_combat_pos)
                        {
                            if (b_pos.X < mousePos.X + 1 && b_pos.X + boutton_action_taille.X > mousePos.X && b_pos.Y < mousePos.Y + 1 && b_pos.Y + boutton_action_taille.Y > mousePos.Y && mouseState.LeftButton == ButtonState.Pressed)
                            {
                                choixJoueur = compte + 1;
                                nManche++;
                                resolutionJoueur = " ";
                                resolutionIA = " ";
                            }
                            compte++;
                        }
                        if (choixJoueur != 10)
                        {
                            switch (choixJoueur)
                            {
                                case 1:
                                    if (!iADef) //on verifie si l'ia se defends ///C'est al qu'il faut changer cette histoire de block
                                    {
                                        classIA.hprestants -= classJoueur.att;
                                        classIA.hpPerdus = classJoueur.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                        resolutionJoueur = "Votre coup a touche !\nL'adversaire a perdu " + classJoueur.att.ToString() + " points de vie";
                                    }
                                    else
                                    {
                                        resolutionJoueur = "D'un geste habile, votre adversaire pare le coup,\nil ne perds pas de points de vie";
                                    }
                                    // Lance l'annimation
                                    animation_en_cour = "damage";
                                    animation_sur = "IA";
                                    break;
                                case 2:
                                    joueurDef = true;
                                    resolutionJoueur = "Vous tentez de bloquer !";
                                    // Lance l'annimation
                                    animation_en_cour = "def";
                                    animation_sur = "joueur";
                                    break;

                                case 3:
                                    classJoueur.speAtt();

                                    if (nomClasseJoueur == "Damager")
                                    {
                                        joueurDmgSpe = true;
                                        // Lance l'annimation
                                        animation_en_cour = "spe_damger";
                                        animation_sur = "IA";
                                    }
                                    else if (nomClasseJoueur == "Tank")
                                    {
                                        joueurTankSpe = true;
                                        // Lance l'annimation
                                        animation_en_cour = "spe_tank";
                                        animation_sur = "IA";
                                    }
                                    else if (nomClasseJoueur == "Ranger")
                                    {
                                        if (joueurRangerCharge >= 2)
                                        {
                                            joueurRangerSpe = true;
                                            joueurRangerCharge = 1;
                                            // Lance l'annimation
                                            animation_en_cour = "spe_ranger_2";
                                            animation_sur = "IA";
                                        }
                                        else
                                        {
                                            joueurRangerCharge += 1;
                                            resolutionJoueur = "Vous prenez le temps d'ajuster votre fleche...";
                                            // Lance l'annimation
                                            animation_en_cour = "spe_ranger_1";
                                            animation_sur = "joueur";
                                        }
                                    }
                                    else if (nomClasseJoueur == "Healer")
                                    {
                                        // Lance l'annimation
                                        animation_en_cour = "spe_healer";
                                        animation_sur = "joueur";
                                    }
                                    if (joueurTankSpe) //si le joueur est tank ET a lance son att spe, on lance une attaque apres le buff stat
                                    {
                                        if (!iADef) //on verifie si l'ia ne se defends pas
                                        {
                                            classIA.hprestants -= classJoueur.att;
                                            classIA.hpPerdus = classJoueur.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                            resolutionJoueur = "Vous sacrifiez 1 point de vie puis vous vous jetez\nsur votre adversaire qui perd " + classJoueur.att.ToString() + " points de vie";
                                        }
                                        else if (joueurTankSpe) //on verifie si le spell du tank est actif, si oui on ne pare qu'1 point de degat
                                        {
                                            classIA.hprestants -= classJoueur.att - 1;
                                            resolutionJoueur = "En sacrifiant 1 point de vie, vous reussissez a traverser\nla parade de votre adversaire !\nIl a perdu " + (classJoueur.att - 1).ToString() + " points de vie.";
                                        }
                                    }
                                    else if (joueurRangerSpe)
                                    {
                                        if (!iADef) //on verifie si l'ia ne se defends pas
                                        {
                                            classIA.hprestants -= 5;
                                            classIA.hpPerdus = 5;
                                            resolutionJoueur = "Votre adversaire prend votre fleche en pleine poirtine,\nil perd 5 points de vie";
                                        }
                                        else
                                        {
                                            classIA.hprestants -= 5;
                                            resolutionJoueur = "Vous tirez votre fleche, votre adversaire tente de la devier,\nsans succes, il perd 5 points de vie";
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
                        // Resolution pour l'ia
                        
                        switch (choixIA)
                        {
                            case 1:
                                if (!joueurDef) //on verifie si le joueur se defends
                                {
                                    classJoueur.hprestants -= classIA.att;
                                    classJoueur.hpPerdus = classIA.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                    resolutionIA = "L'adversaire vous a assene un coup !\nVous perdez " + classIA.att.ToString() + " points de vie...";
                                }
                                else
                                {
                                    resolutionIA = "Vous parez le coup grace a une roulade bien timee";
                                }
                                // Lance l'annimation
                                animation_en_cour = "damage";
                                animation_sur = "joueur";
                                break;

                            case 2:
                                resolutionIA = "L'adversaire tente de se defendre...";
                                // Lance l'annimation
                                animation_en_cour = "def";
                                animation_sur = "IA";
                                break;

                            case 3:
                                classIA.speAtt();
                                if (nomClasseIA == "Damager")
                                {
                                    iaDmgSpe = true;
                                    // Lance l'annimation
                                    animation_en_cour = "spe_damager";
                                    animation_sur = "joueur";
                                }
                                if (nomClasseIA == "Tank")
                                {
                                    iaTankSpe = true;
                                    // Lance l'annimation
                                    animation_en_cour = "spe_tank";
                                    animation_sur = "joueur";
                                }
                                else if (nomClasseIA == "Ranger")
                                {
                                    if (iaRangerCharge >= 2)
                                    {
                                        iaRangerSpe = true;
                                        iaRangerCharge = 1;
                                        // Lance l'annimation
                                        animation_en_cour = "spe_ranger_2";
                                        animation_sur = "joueur";
                                    }
                                    else
                                    {
                                        iaRangerCharge += 1;
                                        // Lance l'annimation
                                        animation_en_cour = "spe_ranger_1";
                                        animation_sur = "IA";
                                        resolutionIA = "Votre adversaire prends le temps d'ajuster son tir...";
                                    }
                                }
                                else if (nomClasseIA == "Healer")
                                {
                                    // Lance l'annimation
                                    animation_en_cour = "spe_healer";
                                    animation_sur = "IA";
                                }
                                
                                if (iaTankSpe)
                                {
                                    if (!joueurDef) //on verifie si le joueur se defends
                                    {
                                        classJoueur.hprestants -= classIA.att;
                                        classJoueur.hpPerdus = classIA.att; //on stock l'info pour le renvoi (on reset a chaque tour)
                                        resolutionIA = "L'adversaire vous a assene un coup puissant ! Grace a son sacrifice de 1 point de vie,\nvous perdez " + classIA.att.ToString() + " points de vie...";
                                    }
                                    else if (iaTankSpe) //on verifie si le spell du tank est actif, si oui on ne pare qu'1 point de degat
                                    {
                                        classJoueur.hprestants -= classIA.att - 1;
                                        resolutionIA = "Votre adversaire enrage et perd 1 point de vie, grace a cela,\nil traverse votre parade et vous perdez " + classIA.att.ToString() + " points de vie...";
                                    }
                                }
                                else if (iaRangerSpe)
                                {
                                    if (!joueurDef) //on verifie si l'ia ne se defends pas
                                    {
                                        classJoueur.hprestants -= 5;
                                        classJoueur.hpPerdus = 5; //on stock l'info pour le renvoi (on reset a chaque tour)
                                        resolutionIA = "La fleche de votre adversaire vous traverse de part en part, vous perdez 5 points de vie";
                                    }
                                    else
                                    {
                                        classJoueur.hprestants -= 5;
                                        resolutionIA = "Vous tentez de parer la fleche tiree par votre adversaire, malheureusement,\nelle est trop puissante et dechire votre armure, vous perdez 5 points de vie";
                                    }
                                }
                                break;
                        }
                        tour = "joueur";
                        verif_hp = true;
                    }


                    if (joueurDmgSpe)
                    {
                        classIA.hprestants -= classJoueur.hpPerdus; //active le renvoie des damages, a bien relier dans la resolution de l'ia
                        resolutionJoueur += " Vous contre-attaquez et il perd " + classIA.hpPerdus + " points de vie";
                        joueurDmgSpe = false;
                    }

                    if (iaDmgSpe)
                    {
                        classJoueur.hprestants -= classIA.hpPerdus; //active le renvoie des damages, a bien relier dans la resolution de l'ia
                        resolutionIA += " Malheureusement vous prenez une contre attaque desesperee et perdez " + classJoueur.hpPerdus + "points de vie";
                        iaDmgSpe = false;
                    }
                    // Verifie si un des deux joueurs n'a plus de HP
                    if (verif_hp)
                    {
                        if (classJoueur.hprestants <= 0 && classIA.hprestants <= 0)
                        {
                            winner = "  Egalite";
                            screen = "end";
                        }
                        else if (classJoueur.hprestants <= 0)
                        {
                            winner = "Vous avez\n perdu la\n  vie...";
                            screen = "end";
                        }
                        else if (classIA.hprestants <= 0)
                        {
                            winner = "Vous avez\n   gagne !";
                            screen = "end";
                        }
                        verif_hp = false;
                    }

                }

                // Code a executer si l'on se trouve dans l'ecran de fin
                else if (screen == "end")
                {

                }
            }

            base.Update(gameTime);
        }

        // Debut de la fonction Draw qui se repete en boucle (c'est ici qu'est geree tout la partie graphique du jeu) 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Affiche les graphisme a l'ecran en fonction de quelle ecran doit etre affiche 
            if (screen == "menu")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(bg_start, new System.Numerics.Vector2(0, 0), Color.White);
                _spriteBatch.Draw(slider_barre, slider_barre_pos, Color.White);
                _spriteBatch.Draw(slider_button, slider_button_pos, Color.White);
                _spriteBatch.Draw(slider_button, slider_button_pos, Color.White);
                _spriteBatch.Draw(button_play, boutton_start_pos, Color.White);
                _spriteBatch.DrawString(endFont, "  Fishing\nSimulator\n      XII", new System.Numerics.Vector2(240, 200), Color.GreenYellow);
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
            else if (screen == "game" || animation_en_cour != "non")
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

                    positionProvi1.X += (i * 50) + 50;
                    positionProvi1.Y -= 70;

                    _spriteBatch.Begin();
                    _spriteBatch.Draw(healthTexture, positionProvi1, Color.White);
                    _spriteBatch.End();
                }
                for (int i = 0; i < classIA.hprestants; i++)
                {
                    System.Numerics.Vector2 positionProvi1 = sprite_IA_pos;

                    positionProvi1.X += (i * 50) + 50;
                    positionProvi1.Y -= 70;
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(healthTexture, positionProvi1, Color.White);
                    _spriteBatch.End();
                }

                _spriteBatch.Begin();
                _spriteBatch.Draw(list_sprite[choixClasseJoueur], sprite_joueur_pos, Color.White);
                _spriteBatch.Draw(list_sprite[choixClasseIA + 4], sprite_IA_pos, Color.White);
                _spriteBatch.Draw(ui_fight, new System.Numerics.Vector2(0, 580), Color.White);

                _spriteBatch.DrawString(font, resolutionJoueur, textbox, Color.Black);
                _spriteBatch.DrawString(font, resolutionIA, textbox2, Color.Black);

                _spriteBatch.Draw(list_boutton_combat_texture[0], list_boutton_combat_pos[0], Color.White);
                _spriteBatch.Draw(list_boutton_combat_texture[1], list_boutton_combat_pos[1], Color.White);
                _spriteBatch.Draw(list_boutton_combat_texture[2 + choixClasseJoueur], list_boutton_combat_pos[2], Color.White);
                _spriteBatch.End();

                // Animation
                if (anim_time == 0)
                {
                    if (animation_sur == "IA")
                    {
                        animation_origine_pos = sprite_IA_pos;
                        animation_pos = animation_origine_pos;
                    }
                    if (animation_sur == "joueur")
                    {
                        animation_origine_pos = sprite_joueur_pos;
                        animation_pos = animation_origine_pos;
                    }
                    anim_frame = 1000;
                    anim_time = 0;
                }


                if (animation_en_cour == "damage")
                {
                    anim_frame += 1;
                    if (anim_frame > 17)
                    {
                        Random rand = new Random();
                        animation_pos.X = animation_origine_pos.X + rand.Next(0, 300);
                        animation_pos.Y = animation_origine_pos.Y + rand.Next(0, 200);
                        anim_frame = 0;
                        anim_time += 1;
                    }

                    _spriteBatch.Begin();
                    _spriteBatch.Draw(list_animation[anim_frame / 6], animation_pos, Color.White);
                    _spriteBatch.End();

                    if (anim_time == 5)
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }
                }
                else if (animation_en_cour == "def")
                {
                    animation_pos.X = animation_origine_pos.X + 80;
                    animation_pos.Y = animation_origine_pos.Y + 140;

                    if (anim_frame < 8)
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(def_effect, animation_pos, Color.White);
                        _spriteBatch.End();
                    }
                    else if (anim_frame >= 16)
                    {
                        anim_frame = 0;
                        anim_time += 1;
                    }
                    anim_frame += 1;

                    if (anim_time == 5)
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }
                }
                else if (animation_en_cour == "spe_damager")
                {
                    if (anim_time == 0) 
                    {
                        anim_time = 1;
                    }

                    if (animation_sur == "IA")
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(eyes_IA, new System.Numerics.Vector2(700, 10), Color.White);
                        _spriteBatch.End();
                    }
                    else
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(eyes_joueur, new System.Numerics.Vector2(700, 10), Color.White);
                        _spriteBatch.End();
                    }
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(eyes_joueur, new System.Numerics.Vector2(700, 10), Color.White);
                    _spriteBatch.End();
                    if (anim_time == 5)
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }

                }
                else if (animation_en_cour == "spe_tank")
                {
                    if (anim_frame == 1000)
                    {
                        anim_frame = 0;
                        anim_time = 1;
                    }
                    if (anim_frame < 50)
                    {
                        anim_frame += 1;
                        if (animation_sur == "IA")
                        {
                            sprite_joueur_pos.X += 10;
                        }
                        else
                        {
                            sprite_IA_pos.X -= 10;
                        }
                    }else if (anim_frame >= 50 && anim_frame <= 80)
                    {
                        if(anim_frame % 10 == 0)
                        {
                            _spriteBatch.Begin();
                            _spriteBatch.Draw(flash, new System.Numerics.Vector2(0,0), Color.White);
                            _spriteBatch.End();
                        }
                        anim_frame += 1;
                    }
                    else if (anim_frame < 130)
                    {
                        anim_frame += 1;
                        if (animation_sur == "IA")
                        {
                            sprite_joueur_pos.X -= 10;
                        }
                        else
                        {
                            sprite_IA_pos.X += 10;
                        }
                    }
                    else
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }
                }
                else if (animation_en_cour == "spe_ranger_1")
                {
                    anim_frame += 1;
                    animation_pos.Y -= 10;
                    if (anim_frame > 30)
                    {
                        Random rand = new Random();
                        animation_pos.X = animation_origine_pos.X + rand.Next(-50, 350);
                        animation_pos.Y = animation_origine_pos.Y + rand.Next(200, 400);
                        anim_frame = 0;
                        anim_time += 1;
                    }
                    if (anim_time == 5)
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }
                    else
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(arrow, animation_pos, Color.White);
                        _spriteBatch.End();
                    }

                }
                else if (animation_en_cour == "spe_ranger_2")
                {
                    anim_frame += 1;
                    if (anim_frame > 11)
                    {
                        Random rand = new Random();
                        animation_pos.X = animation_origine_pos.X + rand.Next(0, 300);
                        animation_pos.Y = animation_origine_pos.Y + rand.Next(0, 200);
                        anim_frame = 0;
                        anim_time += 1;
                    }

                    _spriteBatch.Begin();
                    _spriteBatch.Draw(list_animation[anim_frame / 4], animation_pos, Color.White);
                    _spriteBatch.End();

                    if (anim_time == 10)
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }

                }
                else if (animation_en_cour == "spe_healer")
                {
                    anim_frame += 1;
                    animation_pos.Y -= 3;


                    if (anim_frame > 27)
                    {
                        Random rand = new Random();
                        animation_pos.X = animation_origine_pos.X + rand.Next(0, 300);
                        animation_pos.Y = animation_origine_pos.Y + rand.Next(50, 400);
                        anim_frame = 0;
                        anim_time += 1;
                    }

                    if (anim_time == 4)
                    {
                        animation_en_cour = "non";
                        anim_time = 0;
                        anim_frame = 0;
                    }
                    else
                    {
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(healthTexture, animation_pos, Color.White);
                        _spriteBatch.End();
                    }
                }

            }
            else if (screen == "end")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(bg_ecrand_de_fin, new System.Numerics.Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(endFont, winner, endTextPos, Color.Black);
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
        public string descSpell = " ";
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
                descSpell = "Repliquer les degats subis ce tour (ne vous protege pas des degats)";
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
                descSpell = "Sacrifier 1 point de vie pour gagner 1 point de degats pour ce tour puis attaquer";
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

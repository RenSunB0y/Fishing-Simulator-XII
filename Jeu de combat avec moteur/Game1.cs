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

namespace Jeu_de_combat_avec_moteur
{
    public class Game1 : Game
    {
        #region Déclaration des variables

        private SpriteFont font;
        private SpriteFont endFont;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        string screen = "menu";

        public static Entities playerClass = new Entities();
        public static Entities classIA = new Entities();

        public static string turn = "joueur";
        public static int difficult = 5;
        public static int bestChoice = 0;
        public static int playerChoice = 10;
        public static int playerClassChoice = 10;
        public static int choiceIA = 0;
        public static int choiceClassIA = 10;
        public static string playerClassName = " ";
        public static string nameClassIA = " ";
        public static int turnNumber = 0;
        public static bool isFightOver = false;
        public static bool isPlayerDefenseStance = false;
        public static bool isIADefenseStance = false;
        public static bool isPlayerTankSpellActive = false;
        public static bool isPlayerRangerSpellActive = false;
        public static int playerRangerCharge = 1;
        public static int rangerChargeIA = 1;
        public static bool isIATankSpellActive = false;
        public static bool isIARangerSpellActive = false;
        public static bool isPlayerDamagerSpellActive = false;
        public static bool isIADamagerSpellActive = false;
        public static string playerDisplayText = " ";
        public static string iaDisplayText = " ";
        public static string winner = "  ";
        public static bool isAudioActive = true;
        public static bool controlSlider = false;
        public static bool hpCheck = false;
        public static int animationFrame = 0;
        public static string currentAnimation = "non";
        public static int animationTime = 0;
        public static string animationOn = "  ";
        public static bool isPlayerMove = true;
        bool isSongPlaying = false;
        #endregion

        #region Assets
        Texture2D playButton;
        Texture2D restartButton;
        Texture2D class1Texture;
        Texture2D class2Texture;
        Texture2D class3Texture;
        Texture2D class4Texture;
        Texture2D spriteClass1Texture;
        Texture2D spriteClass2Texture;
        Texture2D spriteClass3Texture;
        Texture2D spriteClass4Texture;
        Texture2D spriteClass1Texture_IA;
        Texture2D spriteClass2Texture_IA;
        Texture2D spriteClass3Texture_IA;
        Texture2D spriteClass4Texture_IA;
        Texture2D hitEffect1;
        Texture2D hitEffect2;
        Texture2D hitEffect3;
        Texture2D defenseEffect;
        Texture2D arrow;
        Texture2D flash;
        Texture2D playerEyes;
        Texture2D iaEyes;
        Texture2D buttonattackPowerack;
        Texture2D attackPowerackTexture;
        Texture2D healthTexture;
        Texture2D fightUI;
        Texture2D attackPowerackButton;
        Texture2D defenseButton;
        Texture2D healerSpecialButton;
        Texture2D damagerSpecialButton;
        Texture2D specialSpecialButton;
        Texture2D tankSpecialButton;
        Texture2D sliderButton;
        Texture2D sliderSlider;
        Texture2D backgroundFight;
        Texture2D backgroundDiff10;
        Texture2D backgroundEndScreen;
        Texture2D backgroundCharacterSelection;
        Texture2D backgroundStartScreen;
        Texture2D gameName;
        SoundEffectInstance songStartScreen;
        SoundEffectInstance sonSelectionScreen;
        SoundEffectInstance songFightScreen;
        SoundEffectInstance songGoodEndingScreen;
        SoundEffectInstance songBadEndingScreen;
        SoundEffectInstance sfxMenuClick;
        SoundEffectInstance sfxHit;
        SoundEffectInstance sfxTankSpell;

        List<Texture2D> listButtonTextureSelection;
        List<System.Numerics.Vector2> listbuttonSizeSelection;
        List<Texture2D> mistSprites;
        List<Texture2D> listButtonFightTextures;
        List<System.Numerics.Vector2> listButtonFightPosition;
        List<Texture2D> listAnimations;
        #endregion

        #region Positions
        System.Numerics.Vector2 buttonStartSize = new System.Numerics.Vector2(258, 96);
        System.Numerics.Vector2 buttonRestartSize = new System.Numerics.Vector2(600, 96);
        System.Numerics.Vector2 buttonSize = new System.Numerics.Vector2(250, 250);
        System.Numerics.Vector2 buttonActionSize = new System.Numerics.Vector2(100, 100);
        System.Numerics.Vector2 buttonSliderSize = new System.Numerics.Vector2(63, 84);
        System.Numerics.Vector2 sliderSliderSize = new System.Numerics.Vector2(840, 72);
        System.Numerics.Vector2 buttonStartPosition = new System.Numerics.Vector2(405, 50);
        System.Numerics.Vector2 buttonRestartPosition = new System.Numerics.Vector2(240, 450);
        System.Numerics.Vector2 boutton1Position = new System.Numerics.Vector2(40, 150);
        System.Numerics.Vector2 boutton2Position = new System.Numerics.Vector2(290, 150);
        System.Numerics.Vector2 boutton3Position = new System.Numerics.Vector2(540, 150);
        System.Numerics.Vector2 boutton4Position = new System.Numerics.Vector2(790, 150);
        System.Numerics.Vector2 buttonattackPowerackPosition = new System.Numerics.Vector2(40, 600);
        System.Numerics.Vector2 bouttonDefensePosition = new System.Numerics.Vector2(160, 600);
        System.Numerics.Vector2 buttonSpellPosition = new System.Numerics.Vector2(280, 600);
        System.Numerics.Vector2 sliderButtonPosition = new System.Numerics.Vector2(150, 515);
        System.Numerics.Vector2 sliderSliderPosition = new System.Numerics.Vector2(150, 520);
        System.Numerics.Vector2 spritePlayerPosition = new System.Numerics.Vector2(50, 175);
        System.Numerics.Vector2 spriteIAPosition = new System.Numerics.Vector2(720, 175);
        System.Numerics.Vector2 mousePosition = new System.Numerics.Vector2(0, 0);
        System.Numerics.Vector2 textBox = new System.Numerics.Vector2(390, 605);
        System.Numerics.Vector2 textBox2 = new System.Numerics.Vector2(390, 655);
        System.Numerics.Vector2 endTextPosition = new System.Numerics.Vector2(250, 160);
        System.Numerics.Vector2 namePosition = new System.Numerics.Vector2(300, 200);
        System.Numerics.Vector2 animationOriginPosition;
        System.Numerics.Vector2 animationPosition;
        #endregion

        /// <summary>
        /// Logique principal du jeu
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// Cette fonction permet de charger tout les assets qui vont etre utilise
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Charge tout les assets qui vont etre utilise
            playButton = Content.Load<Texture2D>("play");
            restartButton = Content.Load<Texture2D>("restart");
            class1Texture = Content.Load<Texture2D>("bouton Choix Damager");
            class2Texture = Content.Load<Texture2D>("bouton Choix Healer");
            class3Texture = Content.Load<Texture2D>("bouton Choix Tank");
            class4Texture = Content.Load<Texture2D>("bouton Choix Ranger");
            spriteClass1Texture = Content.Load<Texture2D>("damager gauche");
            spriteClass2Texture = Content.Load<Texture2D>("healer gauche");
            spriteClass3Texture = Content.Load<Texture2D>("tank gauche");
            spriteClass4Texture = Content.Load<Texture2D>("ranger gauche");
            spriteClass1Texture_IA = Content.Load<Texture2D>("damager droite");
            spriteClass2Texture_IA = Content.Load<Texture2D>("healer droite");
            spriteClass3Texture_IA = Content.Load<Texture2D>("tank droite");
            spriteClass4Texture_IA = Content.Load<Texture2D>("ranger droite");
            hitEffect1 = Content.Load<Texture2D>("effect hit 1");
            hitEffect2 = Content.Load<Texture2D>("effect hit 2");
            hitEffect3 = Content.Load<Texture2D>("effect hit 3");
            defenseEffect = Content.Load<Texture2D>("anim def");
            arrow = Content.Load<Texture2D>("arrow");
            flash = Content.Load<Texture2D>("flash");
            playerEyes = Content.Load<Texture2D>("eyes joueur");
            iaEyes = Content.Load<Texture2D>("eyes IA");
            healthTexture = Content.Load<Texture2D>("Coeur full");
            fightUI = Content.Load<Texture2D>("ui fight");
            attackPowerackButton = Content.Load<Texture2D>("Boutton Atk gb");
            defenseButton = Content.Load<Texture2D>("btn def gb");
            healerSpecialButton = Content.Load<Texture2D>("btn spell gb");
            damagerSpecialButton = Content.Load<Texture2D>("btn spell gb");
            specialSpecialButton = Content.Load<Texture2D>("btn spell gb");
            tankSpecialButton = Content.Load<Texture2D>("btn spell gb");
            sliderSlider = Content.Load<Texture2D>("Slider barre");
            sliderButton = Content.Load<Texture2D>("Slider button");
            backgroundFight = Content.Load<Texture2D>("bg diff 10");
            backgroundDiff10 = Content.Load<Texture2D>("bg diff 10");
            backgroundEndScreen = Content.Load<Texture2D>("bg ecran de fin");
            backgroundCharacterSelection = Content.Load<Texture2D>("bg choix persos");
            backgroundStartScreen = Content.Load<Texture2D>("bg start");
            gameName = Content.Load<Texture2D>("name of the game");
            font = Content.Load<SpriteFont>("Font");
            endFont = Content.Load<SpriteFont>("EndFont");

            // Permet de verifier qu'il y a bien un péripherique audio branche
            try
            {
                songStartScreen = Content.Load<SoundEffect>("start_song").CreateInstance();
                sonSelectionScreen = Content.Load<SoundEffect>("select_song").CreateInstance();
                songFightScreen = Content.Load<SoundEffect>("Musique_jeu_de_combat").CreateInstance();
                songGoodEndingScreen = Content.Load<SoundEffect>("good_end").CreateInstance();
                songBadEndingScreen = Content.Load<SoundEffect>("bad_end").CreateInstance();

                sfxMenuClick = Content.Load<SoundEffect>("menu click").CreateInstance();
                sfxHit = Content.Load<SoundEffect>("hit_sound").CreateInstance();
                sfxTankSpell = Content.Load<SoundEffect>("tank_spe_sound").CreateInstance();

                songStartScreen.Volume = 0.02f;
                sonSelectionScreen.Volume = 0.02f;
                songFightScreen.Volume = 0.02f;
                songGoodEndingScreen.Volume = 0.02f;
                songBadEndingScreen.Volume = 0.02f;
                sfxMenuClick.Volume = 0.02f;
                sfxHit.Volume = 0.02f;
                sfxTankSpell.Volume = 0.02f;
            }
            catch
            {
                isAudioActive = false;
            }

            // Met les textures et les position des boutton et des sprites dans des listes 
            listButtonTextureSelection = new List<Texture2D>() { class1Texture, class2Texture, class3Texture, class4Texture };
            listbuttonSizeSelection = new List<System.Numerics.Vector2>() { boutton1Position, boutton2Position, boutton3Position, boutton4Position };
            mistSprites = new List<Texture2D>() { spriteClass1Texture, spriteClass2Texture, spriteClass3Texture, spriteClass4Texture, spriteClass1Texture_IA, spriteClass2Texture_IA, spriteClass3Texture_IA, spriteClass4Texture_IA };

            listButtonFightTextures = new List<Texture2D>() { attackPowerackButton, defenseButton, damagerSpecialButton, healerSpecialButton, tankSpecialButton, specialSpecialButton };
            listButtonFightPosition = new List<System.Numerics.Vector2>() { buttonattackPowerackPosition, bouttonDefensePosition, buttonSpellPosition };

            listAnimations = new List<Texture2D>() { hitEffect1, hitEffect2, hitEffect3 };


        }

        /// <summary>
        /// Debut de la fonction Update qui se repete en boucle
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {

            if (currentAnimation == "non")
            {
                // Permet d'avoir en memoire tout les input fait par le joueur
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                         Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                var kstate = Keyboard.GetState();
                MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
                mousePosition.X = mouseState.X;
                mousePosition.Y = mouseState.Y;

                // Code a executer si l'on se trouve dans l'ecran de menu
                if (screen == "menu")
                {
                    if (!isSongPlaying && isAudioActive)
                    {
                        songStartScreen.Play();
                        isSongPlaying = true;
                        songStartScreen.IsLooped = true;
                    }
                    // Permet de gerer le slider
                    if (sliderButtonPosition.X < mousePosition.X + 1 && sliderButtonPosition.X + buttonSliderSize.X > mousePosition.X && sliderButtonPosition.Y < mousePosition.Y + 1 && sliderButtonPosition.Y + buttonSliderSize.Y > mousePosition.Y && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        controlSlider = true;
                    }
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        controlSlider = false;
                    }
                    if (controlSlider)
                    {
                        if (mousePosition.X - 50 < sliderSliderPosition.X)
                        {
                            sliderButtonPosition.X = sliderSliderPosition.X;
                        }
                        else if (mousePosition.X - 50 > sliderSliderPosition.X + sliderSliderSize.X - buttonSliderSize.X)
                        {
                            sliderButtonPosition.X = sliderSliderPosition.X + sliderSliderSize.X - buttonSliderSize.X;
                        }
                        else
                        {
                            sliderButtonPosition.X = mousePosition.X - 50;
                        }
                    }
                    // Change la difficultee en fonction du slider
                    difficult = (Convert.ToInt32(sliderButtonPosition.X) - 100) / 73;



                    // Permet de passe a l'ecran de selection de personnage si le boutton start est appuye
                    if (buttonStartPosition.X < mousePosition.X + 1 && buttonStartPosition.X + buttonStartSize.X > mousePosition.X && buttonStartPosition.Y < mousePosition.Y + 1 && buttonStartPosition.Y + buttonStartSize.Y > mousePosition.Y && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        screen = "selec";
                        songStartScreen.Stop();
                        isSongPlaying = false;
                        sfxMenuClick.Play();
                    }

                }
                // Code a executer si l'on se trouve dans l'ecran de selection de personnage
                else if (screen == "selec")
                {
                    // Lance la musique
                    if (!isSongPlaying && isAudioActive)
                    {
                        sonSelectionScreen.Play();
                        isSongPlaying = true;
                        sonSelectionScreen.IsLooped = true;
                    }
                    // Verifie si on appuie sur un boutton de selection de class
                    int compte = 0;
                    foreach (var bPosition in listbuttonSizeSelection)
                    {
                        if (bPosition.X < mousePosition.X + 1 && bPosition.X + buttonSize.X > mousePosition.X && bPosition.Y < mousePosition.Y + 1 && bPosition.Y + buttonSize.Y > mousePosition.Y && mouseState.LeftButton == ButtonState.Pressed)
                        {
                            playerClassChoice = compte;
                        }
                        compte++;
                    }

                    // Assigne le choix du joueur a une class specifique
                    if (playerClassChoice != 10)
                    {
                        switch (playerClassChoice)
                        {
                            case 0:
                                playerClass = new Entities.Damager();
                                playerClassName = "Damager";
                                break;
                            case 1:
                                playerClassName = "Healer";
                                playerClass = new Entities.Healer();
                                break;
                            case 2:
                                playerClassName = "Tank";
                                playerClass = new Entities.Tank();
                                break;
                            case 3:
                                playerClassName = "Ranger";
                                playerClass = new Entities.Ranger();
                                break;
                        }
                        playerClass.hpCurrent = playerClass.hp;
                        screen = "game";
                        sonSelectionScreen.Stop();
                        isSongPlaying = false;
                        // Fait choisir une class aleatoirement par l'IA
                        IAChoice();
                    }

                }
                // Code a executer si l'on se trouve dans l'ecran de jeu
                else if (screen == "game")
                {
                    // Lance la musique
                    if (!isSongPlaying && isAudioActive)
                    {
                        songFightScreen.Play();
                        isSongPlaying = true;
                        songFightScreen.IsLooped = true;
                    }
                    // turn du joueur
                    if (turn == "joueur")
                    {
                            //On initialise le turn : choix du joueur ET de l'ia pour faciliter les interactions.
                        //Reset global des variables
                        isPlayerDefenseStance = false; //reset de la parade 
                        playerClass.hpLost = 0;
                        isPlayerDamagerSpellActive = false;

                        isIADefenseStance = false; //reset de la parade
                        choiceIA = 0;
                        classIA.hpLost = 0;
                        isIADamagerSpellActive = false;

                        if (isIATankSpellActive) //on reset l'etat et l'attackPower si le tank a utilise son spell
                        {
                            classIA.attackPower--;
                            isIATankSpellActive = false;
                        }

                        // Choisi si le choix de l'IA sera optimisee en fonction de la difficutle
                        Random rand = new Random();
                        bestChoice = rand.Next(difficult, 15);

                        // L'IA choisi son action en fonction de sa class et de si son choix est optimise
                        if (nameClassIA == "Damager")
                        {
                            if (bestChoice >= 10)
                            {
                                choiceIA = 1;
                            }
                            else
                            {
                                choiceIA = rand.Next(1, 4);
                            }
                        }
                        else if (nameClassIA == "Healer")
                        {
                            if (bestChoice >= 10)
                            {
                                if (classIA.hpCurrent <= 2)
                                {
                                    choiceIA = 3;
                                }
                                else
                                {
                                    choiceIA = 1;
                                }
                            }
                            else
                            {
                                choiceIA = rand.Next(1, 4);
                            }
                        }
                        else if (nameClassIA == "Tank")
                        {
                            if (bestChoice >= 10)
                            {
                                if (classIA.hpCurrent >= 2)
                                {
                                    choiceIA = 3;
                                }
                                else
                                {
                                    choiceIA = 1;
                                }
                            }
                            else
                            {
                                choiceIA = rand.Next(1, 4);
                            }
                        }
                        else if (nameClassIA == "Ranger")
                        {
                            if (bestChoice >= 10)
                            {
                                if (classIA.hpCurrent >= 2)
                                {
                                    choiceIA = 3;
                                }
                                else if (rangerChargeIA == 2)
                                {
                                    choiceIA = 3;
                                }
                                else
                                {
                                    choiceIA = 1;
                                }
                            }
                            else
                            {
                                choiceIA = rand.Next(1, 4);
                            }
                        }

                        if (choiceIA == 2)
                        {
                            isIADefenseStance = true;
                        }

                        if (isPlayerTankSpellActive) //on reset l'etat et l'attackPower si le tank a utilise son spell
                        {
                            playerClass.attackPower--;
                            isPlayerTankSpellActive = false;
                        }

                        //Verifie si un boutton d'action est appuye
                        int compte = 0;
                        foreach (var bPosition in listButtonFightPosition)
                        {
                            if (bPosition.X < mousePosition.X + 1 && bPosition.X + buttonActionSize.X > mousePosition.X && bPosition.Y < mousePosition.Y + 1 && bPosition.Y + buttonActionSize.Y > mousePosition.Y && mouseState.LeftButton == ButtonState.Pressed)
                            {
                                playerChoice = compte + 1;
                                turnNumber++;
                                playerDisplayText = " ";
                                iaDisplayText = " ";
                            }
                            compte++;
                        }
                        if (playerChoice != 10)
                        {
                            switch (playerChoice)
                            {
                                case 1:
                                    if (!isIADefenseStance) //on verifie si l'ia se defends ///C'est al qu'il faut changer cette histoire de block
                                    {
                                        classIA.hpCurrent -= playerClass.attackPower;
                                        classIA.hpLost = playerClass.attackPower; //on stock l'info pour le renvoi (on reset a chaque turn)
                                        playerDisplayText = "Votre coup a touche !\nL'adversaire a perdu " + playerClass.attackPower.ToString() + " points de vie";
                                    }
                                    else
                                    {
                                        playerDisplayText = "D'un geste habile, votre adversaire pare le coup,\nil ne perds pas de points de vie";
                                    }
                                    // Lance l'annimation
                                    currentAnimation = "damage";
                                    animationOn = "IA";
                                    break;
                                case 2:
                                    isPlayerDefenseStance = true;
                                    playerDisplayText = "Vous tentez de bloquer !";
                                    // Lance l'annimation
                                    currentAnimation = "def";
                                    animationOn = "joueur";
                                    break;

                                case 3:
                                    playerClass.SpecialAttack();

                                    if (playerClassName == "Damager")
                                    {
                                        isPlayerDamagerSpellActive = true;
                                        // Lance l'annimation
                                        currentAnimation = "spe_damager";
                                        animationOn = "IA";
                                    }
                                    else if (playerClassName == "Tank")
                                    {
                                        isPlayerTankSpellActive = true;
                                        // Lance l'annimation
                                        currentAnimation = "spe_tank";
                                        animationOn = "IA";
                                    }
                                    else if (playerClassName == "Ranger")
                                    {
                                        if (playerRangerCharge >= 2)
                                        {
                                            isPlayerRangerSpellActive = true;
                                            playerRangerCharge = 1;
                                            // Lance l'annimation
                                            currentAnimation = "spe_ranger_2";
                                            animationOn = "IA";
                                        }
                                        else
                                        {
                                            playerRangerCharge += 1;
                                            playerDisplayText = "Vous prenez le temps d'ajuster votre fleche...";
                                            // Lance l'annimation
                                            currentAnimation = "spe_ranger_1";
                                            animationOn = "joueur";
                                        }
                                    }
                                    else if (playerClassName == "Healer")
                                    {
                                        // Lance l'annimation
                                        currentAnimation = "spe_healer";
                                        animationOn = "joueur";
                                    }
                                    if (isPlayerTankSpellActive) //si le joueur est tank ET a lance son attackPower spe, on lance une attackPoweraque apres le buff stat
                                    {
                                        if (!isIADefenseStance) //on verifie si l'ia ne se defends pas
                                        {
                                            classIA.hpCurrent -= playerClass.attackPower;
                                            classIA.hpLost = playerClass.attackPower; //on stock l'info pour le renvoi (on reset a chaque turn)
                                            playerDisplayText = "Vous sacrifiez 1 point de vie puis vous vous jetez\nsur votre adversaire qui perd " + playerClass.attackPower.ToString() + " points de vie";
                                        }
                                        else if (isPlayerTankSpellActive) //on verifie si le spell du tank est actif, si oui on ne pare qu'1 point de degat
                                        {
                                            classIA.hpCurrent -= playerClass.attackPower - 1;
                                            playerDisplayText = "En sacrifiant 1 point de vie, vous reussissez a traverser\nla parade de votre adversaire !\nIl a perdu " + (playerClass.attackPower - 1).ToString() + " points de vie.";
                                        }
                                    }
                                    else if (isPlayerRangerSpellActive)
                                    {
                                        if (!isIADefenseStance) //on verifie si l'ia ne se defends pas
                                        {
                                            classIA.hpCurrent -= 5;
                                            classIA.hpLost = 5;
                                            playerDisplayText = "Votre adversaire prend votre fleche en pleine poirtine,\nil perd 5 points de vie";
                                        }
                                        else
                                        {
                                            classIA.hpCurrent -= 5;
                                            playerDisplayText = "Vous tirez votre fleche, votre adversaire tente\nde la devier,sans succes, il perd 5 points de vie";
                                        }
                                    }
                                    break;
                            }
                            playerChoice = 10;
                            turn = "IA";
                        }
                    }
                    // turn de l'IA
                    else if (turn == "IA")
                    {
                        // Resolution pour l'ia
                        
                        switch (choiceIA)
                        {
                            case 1:
                                if (!isPlayerDefenseStance) //on verifie si le joueur se defends
                                {
                                    playerClass.hpCurrent -= classIA.attackPower;
                                    playerClass.hpLost = classIA.attackPower; //on stock l'info pour le renvoi (on reset a chaque turn)
                                    iaDisplayText = "L'adversaire vous a assene un coup !\nVous perdez " + classIA.attackPower.ToString() + " points de vie...";
                                }
                                else
                                {
                                    iaDisplayText = "Vous parez le coup grace a une roulade bien timee";
                                }
                                // Lance l'annimation
                                currentAnimation = "damage";
                                animationOn = "joueur";
                                break;

                            case 2:
                                iaDisplayText = "L'adversaire tente de se defendre...";
                                // Lance l'annimation
                                currentAnimation = "def";
                                animationOn = "IA";
                                break;

                            case 3:
                                classIA.SpecialAttack();
                                if (nameClassIA == "Damager")
                                {
                                    isIADamagerSpellActive = true;
                                    // Lance l'annimation
                                    currentAnimation = "spe_damager";
                                    animationOn = "joueur";
                                }
                                if (nameClassIA == "Tank")
                                {
                                    isIATankSpellActive = true;
                                    // Lance l'annimation
                                    currentAnimation = "spe_tank";
                                    animationOn = "joueur";
                                }
                                else if (nameClassIA == "Ranger")
                                {
                                    if (rangerChargeIA >= 2)
                                    {
                                        isIARangerSpellActive = true;
                                        rangerChargeIA = 1;
                                        // Lance l'annimation
                                        currentAnimation = "spe_ranger_2";
                                        animationOn = "joueur";
                                    }
                                    else
                                    {
                                        rangerChargeIA += 1;
                                        // Lance l'annimation
                                        currentAnimation = "spe_ranger_1";
                                        animationOn = "IA";
                                        iaDisplayText = "Votre adversaire prends le temps d'ajuster son tir...";
                                    }
                                }
                                else if (nameClassIA == "Healer")
                                {
                                    // Lance l'annimation
                                    currentAnimation = "spe_healer";
                                    animationOn = "IA";
                                }
                                
                                if (isIATankSpellActive)
                                {
                                    if (!isPlayerDefenseStance) //on verifie si le joueur se defends
                                    {
                                        playerClass.hpCurrent -= classIA.attackPower;
                                        playerClass.hpLost = classIA.attackPower; //on stock l'info pour le renvoi (on reset a chaque turn)
                                        iaDisplayText = "L'adversaire vous a assene un coup puissant !\nGrace a son sacrifice de 1 point de vie,\nvous perdez " + classIA.attackPower.ToString() + " points de vie...";
                                    }
                                    else if (isIATankSpellActive) //on verifie si le spell du tank est actif, si oui on ne pare qu'1 point de degat
                                    {
                                        playerClass.hpCurrent -= classIA.attackPower - 1;
                                        iaDisplayText = "Votre adversaire enrage et perd 1 point de vie, grace a cela,\nil traverse votre parade et vous perdez " + classIA.attackPower.ToString() + " points de vie...";
                                    }
                                }
                                else if (isIARangerSpellActive)
                                {
                                    if (!isPlayerDefenseStance) //on verifie si l'ia ne se defends pas
                                    {
                                        playerClass.hpCurrent -= 5;
                                        playerClass.hpLost = 5; //on stock l'info pour le renvoi (on reset a chaque turn)
                                        iaDisplayText = "La fleche de votre adversaire\nvous traverse de part en part,\nvous perdez 5 points de vie";
                                    }
                                    else
                                    {
                                        playerClass.hpCurrent -= 5;
                                        iaDisplayText = "Vous tentez de parer la fleche tiree par votre adversaire, malheureusement,\nelle est trop puissante et dechire votre armure, vous perdez 5 points de vie";
                                    }
                                }
                                break;
                        }
                        if (isPlayerDamagerSpellActive)
                        {
                            classIA.hpCurrent -= playerClass.hpLost; //active le renvoie des damages, a bien relier dans la resolution de l'ia
                            playerDisplayText += " Vous contre-attaquez et il perd " + classIA.hpLost + " points de vie";
                            isPlayerDamagerSpellActive = false;
                        }

                        if (isIADamagerSpellActive)
                        {
                            playerClass.hpCurrent -= classIA.hpLost; //active le renvoie des damages, a bien relier dans la resolution de l'ia
                            iaDisplayText += " Malheureusement vous prenez une contre attaque desesperee,\nvous perdez " + playerClass.hpLost + "points de vie";
                            isIADamagerSpellActive = false;
                        }
                        turn = "joueur";
                        hpCheck = true;
                    }



                    // Verifie si un des deux joueurs n'a plus de HP
                    if (hpCheck)
                    {
                        if (playerClass.hpCurrent <= 0 && classIA.hpCurrent <= 0)
                        {
                            winner = "  Egalite";
                            screen = "end";
                            isSongPlaying = false;
                        }
                        else if (playerClass.hpCurrent <= 0)
                        {
                            winner = "Vous avez\n perdu la\n  vie...";
                            screen = "end";
                            isSongPlaying = false;
                        }
                        else if (classIA.hpCurrent <= 0)
                        {
                            winner = "Vous avez\n   gagne !";
                            screen = "end";
                            isSongPlaying = false;
                        }
                        hpCheck = false;
                    }

                }

                // Code a executer si l'on se trouve dans l'ecran de fin
                else if (screen == "end")
                {

                    // Lance la musique

                    if (!isSongPlaying && isAudioActive)
                    {
                        songFightScreen.Stop();
                        if (winner == "Vous avez\n   gagne !")
                        {
                            songGoodEndingScreen.Play();
                            isSongPlaying = true;
                            songGoodEndingScreen.IsLooped = true;
                        }
                        else
                        {
                            songBadEndingScreen.Play();
                            isSongPlaying = true;
                            songBadEndingScreen.IsLooped = true;
                        }
                    }



                    if (buttonRestartPosition.X < mousePosition.X + 1 && buttonRestartPosition.X + buttonRestartSize.X > mousePosition.X && buttonRestartPosition.Y < mousePosition.Y + 1 && buttonRestartPosition.Y + buttonRestartSize.Y > mousePosition.Y && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        sfxMenuClick.Play();
                        if (winner == "Vous avez\n   gagne !")
                        {
                            songGoodEndingScreen.Stop();
                        }
                        else
                        {
                            songBadEndingScreen.Stop();
                        }
                        Restart();
                        screen = "menu";
                        isSongPlaying = false;
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Debut de la fonction Draw qui se repete en boucle
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Affiche les graphisme a l'ecran en fonction de quelle ecran doit etre affiche 
            if (screen == "menu")
            {
                spriteBatch.Begin();
                spriteBatch.Draw(backgroundStartScreen, new System.Numerics.Vector2(0, 0), Color.White);
                spriteBatch.Draw(sliderSlider, sliderSliderPosition, Color.White);
                spriteBatch.Draw(sliderButton, sliderButtonPosition, Color.White);
                spriteBatch.Draw(sliderButton, sliderButtonPosition, Color.White);
                spriteBatch.Draw(playButton, buttonStartPosition, Color.White);
                //spriteBatch.DrawString(endFont, "  Fishing\nSimulator\n      XII", new System.Numerics.Vector2(240, 200), Color.GreenYellow);
                spriteBatch.Draw(gameName, namePosition, Color.White);
                spriteBatch.End();
            }
            else if (screen == "selec")
            {
                spriteBatch.Begin();
                spriteBatch.Draw(backgroundCharacterSelection, new System.Numerics.Vector2(0, 0), Color.White);
                spriteBatch.Draw(listButtonTextureSelection[0], listbuttonSizeSelection[0], Color.White);
                spriteBatch.Draw(listButtonTextureSelection[1], listbuttonSizeSelection[1], Color.White);
                spriteBatch.Draw(listButtonTextureSelection[2], listbuttonSizeSelection[2], Color.White);
                spriteBatch.Draw(listButtonTextureSelection[3], listbuttonSizeSelection[3], Color.White);
                spriteBatch.End();
            }
            else if (screen == "game" || currentAnimation != "non")
            {


                spriteBatch.Begin();
                if (difficult == 10)
                {
                    spriteBatch.Draw(backgroundDiff10, new System.Numerics.Vector2(0, 0), Color.White);
                }
                else
                {
                    spriteBatch.Draw(backgroundFight, new System.Numerics.Vector2(0, 0), Color.White);
                }
                spriteBatch.End();

                for (int i = 0; i < playerClass.hpCurrent; i++)
                {
                    System.Numerics.Vector2 positionProvi1 = spritePlayerPosition;

                    positionProvi1.X += (i * 50) + 50;
                    positionProvi1.Y -= 70;

                    spriteBatch.Begin();
                    spriteBatch.Draw(healthTexture, positionProvi1, Color.White);
                    spriteBatch.End();
                }
                for (int i = 0; i < classIA.hpCurrent; i++)
                {
                    System.Numerics.Vector2 positionProvi1 = spriteIAPosition;

                    positionProvi1.X += (i * 50) + 50;
                    positionProvi1.Y -= 70;
                    spriteBatch.Begin();
                    spriteBatch.Draw(healthTexture, positionProvi1, Color.White);
                    spriteBatch.End();
                }
                // Permet de faire montée et desendre les deux personnages sur l'écran
                if (spritePlayerPosition.Y < 165)
                {
                    isPlayerMove = true;
                }
                else if (spritePlayerPosition.Y > 185)
                {
                    isPlayerMove = false;
                }
                if (isPlayerMove)
                {
                    spritePlayerPosition.Y += 1;
                    spriteIAPosition.Y -= 1;
                }
                else
                {
                    spritePlayerPosition.Y -= 1;
                    spriteIAPosition.Y += 1;
                }



                spriteBatch.Begin();
                spriteBatch.Draw(mistSprites[playerClassChoice], spritePlayerPosition, Color.White);
                spriteBatch.Draw(mistSprites[choiceClassIA + 4], spriteIAPosition, Color.White);
                spriteBatch.Draw(fightUI, new System.Numerics.Vector2(0, 580), Color.White);

                spriteBatch.DrawString(font, playerDisplayText, textBox, Color.Black);
                spriteBatch.DrawString(font, iaDisplayText, textBox2, Color.Black);

                spriteBatch.Draw(listButtonFightTextures[0], listButtonFightPosition[0], Color.White);
                spriteBatch.Draw(listButtonFightTextures[1], listButtonFightPosition[1], Color.White);
                spriteBatch.Draw(listButtonFightTextures[2 + playerClassChoice], listButtonFightPosition[2], Color.White);
                spriteBatch.End();

                // Animation
                if (animationTime == 0)
                {
                    if (animationOn == "IA")
                    {
                        animationOriginPosition = spriteIAPosition;
                        animationPosition = animationOriginPosition;
                    }
                    if (animationOn == "joueur")
                    {
                        animationOriginPosition = spritePlayerPosition;
                        animationPosition = animationOriginPosition;
                    }
                    animationFrame = 1000;
                }


                if (currentAnimation == "damage")
                {
                    animationFrame += 1;
                    if (animationFrame > 17)
                    {
                        Random rand = new Random();
                        animationPosition.X = animationOriginPosition.X + rand.Next(0, 300);
                        animationPosition.Y = animationOriginPosition.Y + rand.Next(0, 200);
                        animationFrame = 0;
                        animationTime += 1;
                        sfxHit.Play();
                    }

                    spriteBatch.Begin();
                    spriteBatch.Draw(listAnimations[animationFrame / 6], animationPosition, Color.White);
                    spriteBatch.End();

                    if (animationTime == 5)
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }
                }
                else if (currentAnimation == "def")
                {
                    animationPosition.X = animationOriginPosition.X + 80;
                    animationPosition.Y = animationOriginPosition.Y + 140;

                    if (animationFrame < 8)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(defenseEffect, animationPosition, Color.White);
                        spriteBatch.End();
                    }
                    else if (animationFrame >= 16)
                    {
                        animationFrame = 0;
                        animationTime += 1;
                    }
                    animationFrame += 1;

                    if (animationTime == 5)
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }
                }
                else if (currentAnimation == "spe_damager")
                {
                    if (animationTime == 0) 
                    {
                        animationTime = 1;
                        animationFrame = 1;
                    }
                    if (animationTime < 5)
                    {
                        if (animationFrame >= 300 || animationFrame <= 0)
                        {
                            animationTime += 1;
                        }
                        if (animationTime == 1 || animationTime == 3)
                        {
                            animationFrame += 8;
                        }
                        else
                        {
                            animationFrame -= 8;
                        }
                        if (animationOn == "IA")
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(playerEyes, new System.Numerics.Vector2(478, 200 + animationFrame), Color.White);
                            spriteBatch.End();
                        }
                        else
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(iaEyes, new System.Numerics.Vector2(478, 200 + animationFrame), Color.White);
                            spriteBatch.End();
                        }
                    }
                    else
                    {
                        animationFrame += 1;
                        if (animationFrame > 17 || animationFrame < 0)
                        {
                            Random rand = new Random();
                            animationPosition.X = animationOriginPosition.X + rand.Next(0, 300);
                            animationPosition.Y = animationOriginPosition.Y + rand.Next(0, 200);
                            animationFrame = 0;
                            animationTime += 1;
                            sfxHit.Play();
                        }

                        spriteBatch.Begin();
                        spriteBatch.Draw(listAnimations[animationFrame / 6], animationPosition, Color.White);
                        spriteBatch.End();

                    }
                    if (animationTime == 11)
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }
                }
                else if (currentAnimation == "spe_tank")
                {
                    if (animationFrame == 1000)
                    {
                        animationFrame = 0;
                        animationTime = 1;
                    }
                    if (animationFrame == 50)
                    {
                        sfxTankSpell.Play();
                    }


                    if (animationFrame < 50)
                    {
                        animationFrame += 1;
                        if (animationOn == "IA")
                        {
                            spritePlayerPosition.X += 10;
                        }
                        else
                        {
                            spriteIAPosition.X -= 10;
                        }
                    }else if (animationFrame >= 50 && animationFrame <= 80)
                    {
                        if(animationFrame % 10 == 0)
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(flash, new System.Numerics.Vector2(0,0), Color.White);
                            spriteBatch.End();
                        }
                        animationFrame += 1;
                    }
                    else if (animationFrame < 130)
                    {
                        animationFrame += 1;
                        if (animationOn == "IA")
                        {
                            spritePlayerPosition.X -= 10;
                        }
                        else
                        {
                            spriteIAPosition.X += 10;
                        }
                    }
                    else
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }
                }
                else if (currentAnimation == "spe_ranger_1")
                {
                    animationFrame += 1;
                    animationPosition.Y -= 10;
                    if (animationFrame > 30)
                    {
                        Random rand = new Random();
                        animationPosition.X = animationOriginPosition.X + rand.Next(-50, 350);
                        animationPosition.Y = animationOriginPosition.Y + rand.Next(200, 400);
                        animationFrame = 0;
                        animationTime += 1;
                    }
                    if (animationTime == 5)
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }
                    else
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(arrow, animationPosition, Color.White);
                        spriteBatch.End();
                    }

                }
                else if (currentAnimation == "spe_ranger_2")
                {
                    animationFrame += 1;
                    if (animationFrame > 11)
                    {
                        Random rand = new Random();
                        animationPosition.X = animationOriginPosition.X + rand.Next(0, 300);
                        animationPosition.Y = animationOriginPosition.Y + rand.Next(0, 200);
                        animationFrame = 0;
                        animationTime += 1;
                        sfxHit.Play();
                    }

                    spriteBatch.Begin();
                    spriteBatch.Draw(listAnimations[animationFrame / 4], animationPosition, Color.White);
                    spriteBatch.End();

                    if (animationTime == 10)
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }

                }
                else if (currentAnimation == "spe_healer")
                {
                    animationFrame += 1;
                    animationPosition.Y -= 3;


                    if (animationFrame > 27)
                    {
                        Random rand = new Random();
                        animationPosition.X = animationOriginPosition.X + rand.Next(0, 300);
                        animationPosition.Y = animationOriginPosition.Y + rand.Next(50, 400);
                        animationFrame = 0;
                        animationTime += 1;
                    }

                    if (animationTime == 4)
                    {
                        currentAnimation = "non";
                        animationTime = 0;
                        animationFrame = 0;
                    }
                    else
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(healthTexture, animationPosition, Color.White);
                        spriteBatch.End();
                    }
                }

            }
            else if (screen == "end")
            {
                spriteBatch.Begin();
                spriteBatch.Draw(backgroundEndScreen, new System.Numerics.Vector2(0, 0), Color.White);
                spriteBatch.DrawString(endFont, winner, endTextPosition, Color.Black);
                spriteBatch.Draw(restartButton, buttonRestartPosition, Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Cette fonction permet de choisir la classe de l'IA
        /// </summary>
        public static void IAChoice()
        {
            Random rand = new Random();
            choiceClassIA = rand.Next(0, 4);
            switch (choiceClassIA)
            {
                case 0:
                    classIA = new Entities.Damager();
                    nameClassIA = "Damager";
                    break;

                case 1:
                    nameClassIA = "Healer";
                    classIA = new Entities.Healer();
                    break;

                case 2:
                    nameClassIA = "Tank";
                    classIA = new Entities.Tank();
                    break;
                case 3:
                    nameClassIA = "Ranger";
                    classIA = new Entities.Ranger();
                    break;
            }
            classIA.hpCurrent = classIA.hp;
        }

        /// <summary>
        /// Cette fonction permet de redemarrer le jeu
        /// </summary>
        public static void Restart()
        {
            playerClass = new Entities();
            classIA = new Entities();
            turn = "joueur";
            difficult = 5;
            bestChoice = 0;
            playerChoice = 10;
            playerClassChoice = 10;
            choiceIA = 0;
            choiceClassIA = 10;
            playerClassName = " ";
            nameClassIA = " ";
            turnNumber = 0;
            isFightOver = false;
            isPlayerDefenseStance = false;
            isIADefenseStance = false;
            isPlayerTankSpellActive = false;
            isPlayerRangerSpellActive = false;
            playerRangerCharge = 1;
            rangerChargeIA = 1;
            isIATankSpellActive = false;
            isIARangerSpellActive = false;
            isPlayerDamagerSpellActive = false;
            isIADamagerSpellActive = false;
            playerDisplayText = " ";
            iaDisplayText = " ";
            winner = "  ";
            isAudioActive = true;
            controlSlider = false;
            hpCheck = false;
            animationFrame = 0;
            currentAnimation = "non";
            animationTime = 0;
            animationOn = "  ";
        }
    }

    /// <summary>
    /// Cette classe permet de creer les Entities du jeu
    /// </summary>
    public class Entities
    {
        public int hpCurrent;
        public int hp;
        public int hpLost = 0;
        public int attackPower = 1;
        public string spellDescriptions = " ";
        public virtual void SpecialAttack()
        { }

        /// <summary>
        /// Ce constructeur permet de creer la classe Damager
        /// </summary>
        public class Damager : Entities
        {
            public override void SpecialAttack()
            {
                Game1.isPlayerDamagerSpellActive = true;
            }
            public Damager()
            {
                hp = 3;
                attackPower = 2;
                spellDescriptions = "Repliquer les degats subis ce turn (ne vous protege pas des degats)";
            }
        }

        /// <summary>
        /// ce constructeur permet de creer la classe Healer
        /// </summary>
        public class Healer : Entities
        {
            public override void SpecialAttack()
            {
                //les conditions verifient et limitent le gain de hp aux hpmax
                if (hpCurrent + 2 <= hp)
                { hpCurrent += 2; }
                else if (hpCurrent + 1 == hp)
                { hpCurrent++; }
                else { Console.WriteLine(" Les points de vie sont au maximum, le sort n'a pas eu d'effet"); }
            }
            public Healer()
            {
                hp = 4;
                spellDescriptions = "Regagner 2 points de vie";
            }
        }

        /// <summary>
        /// ce constructeur permet de creer la classe Tank
        /// </summary>
        public class Tank : Entities
        {
            public override void SpecialAttack()
            {
                hpCurrent--;
                attackPower++;
            }
            public Tank()
            {
                hp = 5;
                spellDescriptions = "Sacrifier 1 point de vie pour gagner 1 point de degats pour ce turn puis attackPoweraquer";
            }
        }

        /// <summary>
        /// ce constructeur permet de creer la classe Ranger
        /// </summary>
        public class Ranger : Entities
        {
            public override void SpecialAttack()
            {}
            public Ranger()
            {
                hp = 3;
                attackPower = 2;
                spellDescriptions = "2 turns pour charger une attackPoweraque qui inflige 5 damages";
            }
        }
    }
}

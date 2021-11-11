using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TerrabornLeveling.Perks;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using WebmilioCommons.Extensions;
using WebmilioCommons.Inputs;

namespace TerrabornLeveling.UI;

public class SkillsMenu : UIState
{
    private readonly UIPanel container;
    
    private int _activeSkill;
    private float _cameraX;
    private float _cameraHSpeed;
    private SkillElement[] _skills;

    public SkillsMenu()
    {
        container = new()
        {
            Width = StyleDimension.Fill,
            Height = StyleDimension.Fill,

            BackgroundColor = new(0, 0, 0, 0.75f),
            BorderColor = new(0, 0, 0, 0.75f)
        };

        Append(container);
    }

    public void PopulateSkills(TLPlayer player)
    {
        container.RemoveAllChildren();

        _skills = new SkillElement[player.Skills.Count];
        player.Skills.Do((skill, i) => container.Append(_skills[i] = new SkillElement(skill, i, OnSkillElementClick)));

        _activeSkill = _skills.Length / 2;

        UpdatePosition();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (TerrabornLeveling.Development)
        {
            if (TerrabornLeveling.Instance.DevelopmentAction.JustPressed && OperatingSystem.IsWindows())
            {
                var path = $"{Environment.GetEnvironmentVariable("tmp")}\\{Path.GetRandomFileName()}.txt";

                using FileStream fs = File.OpenWrite(path);
                using StreamWriter sw = new(fs);

                List<IPerk> sortedPerks = new(_skills[_activeSkill].Skill.Perks);
                sortedPerks.Sort((x, y) => x.Name.CompareTo(y.Name));
                    
                sortedPerks.Do(delegate (IPerk perk)
                {
                    sw.WriteLine(new StringBuilder()
                        .Append(perk.GetType().Name)
                        .Append(": ")
                        .Append(perk.Name)
                        .Append(": ")
                        .AppendFormat("{0},{1}", perk.Visuals.Position.X, perk.Visuals.Position.Y)
                        .ToString());
                });

                try
                {
                    Process.Start("notepad",path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        var keys = ModContent.GetInstance<KeyboardManager>();

        UpdateCameraPosition();

        if (keys.justPressed[(int)Keys.Left])
        {
            GoPrevious();
        }
        else if (keys.justPressed[(int)Keys.Right])
        {
            GoNext();
        }
    }

    private void UpdateCameraPosition()
    {
        // Camera scrolling
        float cameraDestination = _activeSkill * SkillElement.SizeWidth;
        if (_cameraX < cameraDestination)
        {
            _cameraHSpeed += 0.5f;
            if (_cameraHSpeed > 75)
                _cameraHSpeed = 75;
        }
        if (_cameraX > cameraDestination)
        {
            _cameraHSpeed -= 0.5f;
            if (_cameraHSpeed < -75)
                _cameraHSpeed = -75;
        }

        if (_cameraHSpeed != 0)
        {
            _cameraX += _cameraHSpeed;
            UpdatePosition();
        }

        if ((_cameraHSpeed > 0 && _cameraX > cameraDestination) || (_cameraHSpeed < 0 && _cameraX < cameraDestination))
        {
            _cameraX = cameraDestination;
            _cameraHSpeed = 0;
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        for (int i = 0; i < _skills.Length; i++)
        {
            //var offsetI = (i - _activeSkill);

            _skills[i].Left = new(-_cameraX + i * SkillElement.SizeWidth, 0f);
            _skills[i].Recalculate();
        }
    }

    private void GoPrevious()
    {
        _activeSkill -= 1;

        if (_activeSkill < 0)
            _activeSkill = _skills.Length - 1;

        //UpdatePosition();

        //_skills.Do(s => s.Recalculate());
    }

    private void GoNext()
    {
        _activeSkill += 1;

        if (_activeSkill >= _skills.Length)
            _activeSkill = 0;

        //UpdatePosition();

        //_skills.Do(s => s.Recalculate());
    }

    private void OnSkillElementClick(SkillElement skill)
    {
        _activeSkill = skill.CreationIndex;
        /*if (skill.CreationIndex > _activeSkill)
        {
            GoNext();
        }
        else if (skill.CreationIndex < _activeSkill)
        {
            GoPrevious();
        }*/
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Main.LocalPlayer.mouseInterface = true;
    }

    public override void OnActivate()
    {
        SoundEngine.PlaySound(SoundID.MenuOpen);
    }

    public override void OnDeactivate()
    {
        SoundEngine.PlaySound(SoundID.MenuClose);
    }

    public int ActivePanel { get; } = 0;
}
﻿using ChemistRecipe.Experiment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChemistRecipe.UI
{
    public class SceneController : MonoBehaviour
    {

        [Header("Course Behavior")]
        public CourseBehaviour courseBehaviour;

        [Header("Canvas References")]
        public Canvas PlayCanvas;
        public Canvas SidebarMenuCanvas;
        public Canvas CheckListCanvas;
        public Canvas DebugCanvas;

        [Header("Play Overlay")]
        public Image Cursor;
        public Button MenuButton;
        public Button FinishCourseButton;
        public Button StirButton;
        public Text TimerText;
        public Text InstructionText;
        public Text EquipmentDetailText;

        [Header("Menu Buttons")]
        public Button ResumeButton;
        public Button InstructionButton;
        public Button CheckListButton;
        public Button SettingButton;
        public Button RestartButton;
        public Button MainMenuButton;

        [Header("Checklist Buttons")]
        public Button CloseCheckListButton;

        // Internal
        private FillableEquipment currentHitEquipment = null;

        // Use this for initialization
        void Start()
        {
            SetupUI();
        }

        void SetupUI()
        {
            // Default hide sidebar canvas
            SidebarMenuCanvas.enabled = false;
            CheckListCanvas.enabled = false;

            // Disable Stir & Finish Course Button
            StirButton.gameObject.SetActive(false);
            FinishCourseButton.gameObject.SetActive(false);

            // Hide Equipment Detail
            EquipmentDetailText.enabled = false;
            EquipmentDetailText.GetComponentInParent<Image>().enabled = false;

            // Add Button action
            // Play Overlay
            MenuButton.onClick.AddListener(ShowSidebarMenu);
            StirButton.onClick.AddListener(() =>
            {
                if (currentHitEquipment != null)
                {
                    currentHitEquipment.Stir();
                }
            });
            FinishCourseButton.onClick.AddListener(courseBehaviour.FinishCourse);

            // Sidebar Menu
            ResumeButton.onClick.AddListener(HideAllSidebar);
            CheckListButton.onClick.AddListener(ShowCheckList);
            RestartButton.onClick.AddListener(HideAllSidebar);
            RestartButton.onClick.AddListener(courseBehaviour.RestartCourse);
            MainMenuButton.onClick.AddListener(courseBehaviour.StopCourse);

            // CheckList
            CloseCheckListButton.onClick.AddListener(HideAllSidebar);
        }

        public void TogglePlayCanvas(bool flag)
        {
            PlayCanvas.enabled = flag;
            DebugCanvas.enabled = flag;
        }

        public void ShowSidebarMenu()
        {
            SidebarMenuCanvas.enabled = true;
            TogglePlayCanvas(false);
        }

        public void ShowCheckList()
        {
            SidebarMenuCanvas.enabled = false;
            CheckListCanvas.enabled = true;
        }

        public void HideAllSidebar()
        {
            SidebarMenuCanvas.enabled = false;
            CheckListCanvas.enabled = false;

            TogglePlayCanvas(true);
        }

        public void HideAllCanvas()
        {
            TogglePlayCanvas(false);

            SidebarMenuCanvas.enabled = false;
            CheckListCanvas.enabled = false;
        }

        public void ShowFinishButton()
        {
            FinishCourseButton.gameObject.SetActive(true);
        }

        public void ShowStirButton(FillableEquipment newHitEquipment)
        {
            currentHitEquipment = newHitEquipment;
            StirButton.gameObject.SetActive(true);
            Cursor.enabled = false;
        }

        public void HideStirButton()
        {
            currentHitEquipment = null;
            StirButton.gameObject.SetActive(false);
            Cursor.enabled = true;
        }

        public void ChangeInstructionMessage(string text)
        {
            InstructionText.text = "  ";
            InstructionText.text = text;
            InstructionText.text = text + " ";
        }

        public void ShowEquipmentDetail(string text)
        {
            EquipmentDetailText.enabled = true;
            EquipmentDetailText.GetComponentInParent<Image>().enabled = true;

            EquipmentDetailText.text = text;
            EquipmentDetailText.text = text + " ";
        }

        public void HideEquipmentDetail()
        {
            EquipmentDetailText.enabled = false;
            EquipmentDetailText.GetComponentInParent<Image>().enabled = false;

            EquipmentDetailText.text = "  ";
            EquipmentDetailText.text = " ";
        }
        
    }
}

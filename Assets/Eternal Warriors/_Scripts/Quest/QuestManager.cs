using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public QuestType questType;
    public int requiredAmount;
    public int currentAmount;
    public bool isCompleted;
    public int rewardCoins;

    public Quest(QuestType questType, int amount, int reward)
    {
        this.questType = questType;
        requiredAmount = amount;

        currentAmount = PlayerPrefs.GetInt(questType.ToString(), 0);
        isCompleted = PlayerPrefs.GetInt(questType.ToString() + "_completed", 0) == 1;
        rewardCoins = reward;
    }

    public void CheckCompletion()
    {
        if (currentAmount >= requiredAmount && !isCompleted)
        {
            isCompleted = true;
            PlayerPrefs.SetInt(questType.ToString() + "_completed", 1);
        }
    }

    public void RewardPlayer()
    {
        CointManager.instance.AddCoint(rewardCoins);
        QuestManager.instance.SetupNextQuest(questType);

    }

    public void SaveQuest()
    {
        PlayerPrefs.SetInt(questType.ToString(), currentAmount);
    }
}

public enum QuestType
{
    EnemySworder,
    EnemyBower,
    EnemyHourser,
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests = new List<Quest>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
            Destroy(gameObject); 

    }

    private void Start()
    {
        quests.Add(new Quest(QuestType.EnemySworder, 10, 200));
        quests.Add(new Quest(QuestType.EnemyBower, 10, 200));
        quests.Add(new Quest(QuestType.EnemyHourser, 10, 200));
        foreach (Quest quest in quests)
        {
            LoadQuestProgress(quest);
        }
    }

    public void AddQuest(QuestType questType, int requiredAmount, int reward)
    {
        quests.Add(new Quest(questType, requiredAmount, reward));
    }

    public void UpdateQuest(QuestType questType, int amount)
    {
        foreach (Quest mission in quests)
        {
            if (!mission.isCompleted && mission.questType == questType)
            {
                mission.currentAmount += amount;
                mission.CheckCompletion();
                mission.SaveQuest();
            }
        }
    }
    public void SetupNextQuest(QuestType questType)
    {
        foreach (Quest mission in quests)
        {
            if (mission.questType == questType && mission.isCompleted)
            {

                int newRequiredAmount = mission.requiredAmount + 2;
                int newReward = mission.rewardCoins + 10;

                AddQuest(questType, newRequiredAmount, newReward);
            }
        }
    }
    //public void DailyLoginReward(int rewardCoins)
    //{
    //    CointManager.instance.AddCoint(rewardCoins);
    //}
    public void LoadQuestProgress(Quest quest)
    {
        quest.isCompleted = PlayerPrefs.GetInt(quest.questType.ToString() + "_Completed", 0) == 1;
        quest.currentAmount = PlayerPrefs.GetInt(quest.questType.ToString() + "_CurrentAmount", 0);
    }
    public void SaveQuestProgress(Quest quest)
    {
        PlayerPrefs.SetInt(quest.questType.ToString() + "_Completed", quest.isCompleted ? 1 : 0);
        PlayerPrefs.SetInt(quest.questType.ToString() + "_CurrentAmount", quest.currentAmount);
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

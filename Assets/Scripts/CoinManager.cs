using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
   public static CoinManager Instance; 
   private int _balance;
   private int _balanceSave;
   private string _keySaveBalance = "SaveBalance";
   private TMP_Text _textBalance;

   public void Awake()
   {
      Instance = this;
      DontDestroyOnLoad(this);
      
   }

   private void Start()
   {
      LoadData();
      ShowText();
   }
   
   public void SaveData()
   {
      _balanceSave = _balance;
      PlayerPrefs.SetInt(_keySaveBalance,_balanceSave);
      PlayerPrefs.Save();
   }

   public void LoadData()
   {
      if (PlayerPrefs.HasKey(_keySaveBalance))
      {
         _balance = PlayerPrefs.GetInt(_keySaveBalance);
      }
   }
   
   public void IncreaseCoin(int count)
   {
      _balance += count;
      ShowText();
   }

   public void DecreaseCoin(int count)
   {
      _balance -= count;
      ShowText();
   }

   public void ShowText()
   {
      _textBalance = FindObjectOfType<Balance>().GetComponent<TMP_Text>();
      _textBalance.SetText("Balance:"+_balance.ToString());
   }
}

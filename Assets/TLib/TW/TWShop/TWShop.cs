using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Purchasing;

public class TWShop : TWBoard//, IStoreListener
{
 //   public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
 //   {
 //       Debug.Log("OnInitialized: PASS");

 //       // Overall Purchasing system, configured with products for this application.
 //       m_StoreController = controller;
 //       // Store specific subsystem, for accessing device-specific store features.
 //       m_StoreExtensionProvider = extensions;
 //   }

 //   public void OnInitializeFailed(InitializationFailureReason error)
 //   {
 //       Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
 //       TW.I.AddWarning("", "Shop Init Error!");
 //   }

 //   public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
 //   {
 //       Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", i.definition.storeSpecificId, p));
 //       TW.I.AddWarning("", "Purchase Failed!");
 //   }

 //   public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
 //   {

 //       foreach (KeyValuePair<int, st_shop> ITEM in st_shopTable.I.VALUE)
 //       {
            
 //           if (String.Equals(args.purchasedProduct.definition.id, ITEM.Value.stringid, StringComparison.Ordinal))
 //           {
 //               if( ITEM.Value.is_ads==true)
 //               {
 //                   PlayerInfo.IS_REMOVED_ADS.SetAndSave(1);
 //               }
 //               else
 //               {
 //                   if(ITEM.Value.coin>0)
 //                   {
 //                       PlayerInfo.COIN.PlusAndSave(ITEM.Value.coin);
 //                   }
 //                   else
 //                   {
 //                       PlayerInfo.GEM.PlusAndSave(ITEM.Value.gem);
 //                   }
 //                   if (MainMenu.I != null) MainMenu.I.UpdateGemCoinInfo();
 //               }
 //               TW.I.AddWarning("", "Purchase successful!"); 
 //               break;
 //           }
 //       }
       

 //       return PurchaseProcessingResult.Complete;
 //   }


 //   private static IStoreController m_StoreController;          // The Unity Purchasing system.
 //   private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems
 //   public static TWShop I;
 //   private void Awake()
 //   {
 //       I = this;
 //   }
 //   void Start ()
 //   {
 //       base.InitTWBoard();
 //       if (m_StoreController == null)
 //       {
 //           InitializePurchasing();
 //       }
 //   }
 //   public void InitializePurchasing()
 //   {
 //       if (IsInitialized())
 //       {
 //           return;
 //       }
 //       //var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

 //       foreach( KeyValuePair<int,st_shop> ITEM in st_shopTable.I.VALUE)
 //       {
 //           //builder.AddProduct(ITEM.Value.stringid, ProductType.Consumable);
 //       }
        
 //       //UnityPurchasing.Initialize(this, builder);
 //   }
 //   private bool IsInitialized()
 //   {
 //       return m_StoreController != null && m_StoreExtensionProvider != null;
 //   }
 //   void Update ()
 //   {
		
	//}
 //   public void UserClick(st_shop ST_SHOP)
 //   {
 //       BuyProductID(ST_SHOP.stringid);
 //   }
 //   void BuyProductID(string productId)
 //   {
 //       if (IsInitialized())
 //       {
 //           Product product = m_StoreController.products.WithID(productId);
 //           if (product != null && product.availableToPurchase)
 //           {
 //               Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
 //               m_StoreController.InitiatePurchase(product);
 //           }
 //           else
 //           {
 //               Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
 //           }
 //       }
 //       else
 //       {
 //           Debug.Log("BuyProductID FAIL. Not initialized.");
 //       }
 //   }
 //   public void RestorePurchases()
 //   {
 //       if (!IsInitialized())
 //       {
 //           Debug.Log("RestorePurchases FAIL. Not initialized.");
 //           return;
 //       }
 //       if (Application.platform == RuntimePlatform.IPhonePlayer ||
 //           Application.platform == RuntimePlatform.OSXPlayer)
 //       {
 //           Debug.Log("RestorePurchases started ...");
 //           //var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
 //          // apple.RestoreTransactions((result) => {
 //               //Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
 //          // });
 //       }
 //       else
 //       {
 //           Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
 //       }
 //   }
}

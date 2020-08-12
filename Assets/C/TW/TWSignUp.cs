using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class TWSignUp : TWBoard
{
	public InputField TEXTFIELD_USERNAME;
	public InputField TEXTFIELD_PASS1;
	public InputField TEXTFIELD_PASS2;
	public InputField TEXTFIELD_FAMILYNAME;
	public InputField TEXTFIELD_GIVENNAME;
	public Dropdown DROPDOWN_PREFIX;
	public InputField TEXTFIELD_ID;
	public InputField TEXTFIELD_PHONE;
	public Dropdown DROPDOWN_GENDER;
	public InputField TEXTFIELD_BIRTHDAY;
	public Dropdown DROPDOWN_ADDR_TYPE;
	public InputField TEXTFIEL_ADDR_ZIPCODE;
	public InputField TEXTFIEL_ADDR_COUNTRY;
	public InputField TEXTFIEL_ADDR_STATE;
	public InputField TEXTFIEL_ADDR_CITY;
	public InputField TEXTFIEL_ADDR_STREET;
	public InputField TEXTFIEL_ADDR_BUILDING;
	void Start () 
    {
        base.InitTWBoard();
	}
	void Update () 
    {
	
	}
	public void OnClickSignUp()
    {
		Patient patient = new Patient();
		HumanName p_humanName = new HumanName();
		p_humanName.Family = TEXTFIELD_FAMILYNAME.text;
		p_humanName.WithGiven(TEXTFIELD_GIVENNAME.text);
		p_humanName.Prefix = new string[] { DROPDOWN_PREFIX.captionText.text };
		p_humanName.Use = HumanName.NameUse.Official;
		Identifier p_Identifier = new Identifier("jaist.ac.jp", TEXTFIELD_ID.text);
		var p_contact = new Hl7.Fhir.Model.ContactPoint(Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Phone,
			Hl7.Fhir.Model.ContactPoint.ContactPointUse.Mobile,
			TEXTFIELD_PHONE.text);


		AdministrativeGender p_gender;
		if (DROPDOWN_GENDER.value == 0)
			p_gender = AdministrativeGender.Male;
		else if (DROPDOWN_GENDER.value == 1)
			p_gender = AdministrativeGender.Female;
		else
			p_gender = AdministrativeGender.Other;

		
		Address p_address = new Address();

		if (DROPDOWN_ADDR_TYPE.value == 0)
			p_address.Use = Address.AddressUse.Home;
		else if (DROPDOWN_ADDR_TYPE.value == 1)
			p_address.Use = Address.AddressUse.Work;
		else
			p_address.Use = Address.AddressUse.Temp;
		p_address.Type = Address.AddressType.Postal;
		p_address.Country = TEXTFIEL_ADDR_COUNTRY.text;
		p_address.State = TEXTFIEL_ADDR_STATE.text;
		p_address.PostalCode = TEXTFIEL_ADDR_ZIPCODE.text;
		p_address.City = TEXTFIEL_ADDR_CITY.text;
		p_address.Line = new string[] { TEXTFIEL_ADDR_STREET.text };
		p_address.Text = TEXTFIEL_ADDR_BUILDING.text;


		// Create patient with info
		patient.Name.Add(p_humanName);
		patient.Identifier.Add(p_Identifier);
		patient.Telecom.Add(p_contact);
		patient.Address.Add(p_address);


		if (Date.IsValidValue(TEXTFIELD_BIRTHDAY.text))
		{
			Debug.Log("OK IRTHDAY");
			patient.BirthDate = TEXTFIELD_BIRTHDAY.text;
		}
		else
			patient.BirthDateElement = Hl7.Fhir.Model.Date.Today();// System.DateTime.Parse(TEXTFIELD_BIRTHDAY.text);
		patient.Gender = p_gender;
		// Create Fhir client instance


		TW.I.AddWarning("", "Signning up...");
		StartCoroutine(startregister(patient));
	}
    
	IEnumerator startregister(Patient patient)
    {
		yield return new WaitForSeconds(0.1f);
		var client = new FhirClient("http://hapi.fhir.org/baseR4");
		var ceated_p = client.Create(patient);
		Debug.Log("ID=" + ceated_p.Id);
		int idd = int.Parse(ceated_p.Id);
		UserInformation.USERSAVEINFO.AddUserInfo(TEXTFIELD_USERNAME.text, TEXTFIELD_PASS1.text, idd);
		UserInfo ui = UserInformation.USERSAVEINFO.GetUserInfobyID(idd);
		UserInformation.CURRENT_USER_ID.SetAndSave(UserInformation.USERSAVEINFO.USERS.IndexOf(ui));
		UserTab.I.Start();

		TW.I.AddWarning("", "Sign Up Success!");
		ClickX();
	}
}

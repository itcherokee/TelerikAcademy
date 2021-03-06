﻿using System;

/// <summary>
/// Task: "10. A marketing firm wants to keep record of its employees. 
/// Each record would have the following characteristics – first name, family name, age, gender (m or f), 
/// ID number, unique employee number (27560000 to 27569999). Declare the variables needed to keep 
/// the information for a single employee using appropriate data types and descriptive names."
/// </summary>
public class Employee
{
    private char gender;
    private int employeeId;

    public char Gender
    {
        get
        {
            return this.gender;
        }

        set
        {
            if (value == 'm' || value == 'f')
            {
                this.gender = value;
            }
            else
            {
                throw new ArgumentException("Invalid value provided for Gender!");
            }
        }
    }

    public string FirstName { get; set; }

    public string FamilyName { get; set; }

    public byte Age { get; set; }

    public string PersonalId { get; set; }

    public int EmployeeId 
    {
        get
        {
            return this.employeeId;
        } 
        
        set
        {
            if (value >= 27560000 && value <= 27569999)
            {
                this.employeeId = value;
            }
            else
            {
                throw new ArgumentException("Invalid value provided for EmployeeID!");
            }
        }
    }
}

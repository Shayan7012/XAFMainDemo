;#DropDB MySolutionEasyTest

#Application MySolution.Win
#Application MySolution.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef MySolution.Win

*Action About...
 
*Action OK

#EndIf

#IfDef MySolution.Web
*Action Navigation(My Details)
#EndIf

# Invite-for-a-break---ITMarathon
## **First place** at the IT Marathon, desktop and mobile application section!
## Launch: April 1, 2023
## Languages used: C#, SQL
## Working time: 10h
### The project has many bugs because I didn't have time. But, in 10 hours, it's great how many things I managed to implement!

<br><br><br>

<div id="tablepress-2_wrapper" class="dataTables_wrapper no-footer"><table id="tablepress-2" class="tablepress tablepress-id-2 dataTable no-footer" role="grid">
<thead>
<tr class="row-1 odd" role="row"><th class="column-1 sorting_disabled" rowspan="1" colspan="1" style="width: 79.6562px;">Req ID</th><th class="column-2 sorting_disabled" rowspan="1" colspan="1" style="width: 607.078px;">Requirements</th><th class="column-3 sorting_disabled" rowspan="1" colspan="1" style="width: 138.266px;">Points</th></tr>
</thead>
<tbody class="row-hover">
<tr class="row-2 even">
	<td class="column-1">IFB_001</td><td class="column-2">The application will have 5 pages:<br>
1. Login page<br>
2. Home page<br>
3. Page for sending requests<br>
4. Page for viewing your requests<br>
5. Profile page</td><td class="column-3">5p</td>
</tr><tr class="row-3 odd">
	<td class="column-1"></td><td class="column-2">Login</td><td class="column-3">10p</td>
</tr><tr class="row-4 even">
	<td class="column-1">IFB_002</td><td class="column-2">The user will login using the username and password from the database provided and by sending a request to the server.<br>
The details of the login and logout method can be found in the login sheet.</td><td class="column-3">4p</td>
</tr><tr class="row-5 odd">
	<td class="column-1">IFB_003</td><td class="column-2">If the user has logged in, he will not be logged off if the application closes. When the application is opened again, the Login page will not appear.</td><td class="column-3">4p</td>
</tr><tr class="row-6 even">
	<td class="column-1">IFB_004</td><td class="column-2">If the input credentials are not in the database/ are incorrect, an error message will be displayed.</td><td class="column-3">2p</td>
</tr><tr class="row-7 odd">
	<td class="column-1"></td><td class="column-2">Database</td><td class="column-3">10p</td>
</tr><tr class="row-8 even">
	<td class="column-1">IFB_005</td><td class="column-2">The application will use a database in which there will be executed CRUD (Create, Read, Update, Delete) operations. The content of the database will reflect the content of the data in the application, and by changing them, the content from the database will be changed too. You can use any type of database including JSON/XML/MongoDB etc as long as is stored locally.</td><td class="column-3"></td>
</tr><tr class="row-9 odd">
	<td class="column-1"></td><td class="column-2">LoginView</td><td class="column-3">5p</td>
</tr><tr class="row-10 even">
	<td class="column-1">IFB_006</td><td class="column-2">This view should have input fields for username &amp; passwords &amp; a button for Login.</td><td class="column-3">1p</td>
</tr><tr class="row-11 odd">
	<td class="column-1">IFB_007</td><td class="column-2">The information from the password field will be hidden (star/dots/asterisks/etc in place of characters)</td><td class="column-3">1p</td>
</tr><tr class="row-12 even">
	<td class="column-1">IFB_008</td><td class="column-2">An user that is not logged in will have access only to the LoginView.</td><td class="column-3">1p</td>
</tr><tr class="row-13 odd">
	<td class="column-1">IFB_009</td><td class="column-2">If the server is sending a positive response, the user will be redirected to Home page and he will be marked as logged in.</td><td class="column-3">1p</td>
</tr><tr class="row-14 even">
	<td class="column-1">IFB_010</td><td class="column-2">If the server is sending a negative response, an error message will be displayed and the user will remain marked as logged out.</td><td class="column-3">1p</td>
</tr><tr class="row-15 odd">
	<td class="column-1"></td><td class="column-2">Home</td><td class="column-3">17p </td>
</tr><tr class="row-16 even">
	<td class="column-1">IFB_011</td><td class="column-2">It will contain an icon for each of the pages above (except for the login and home pages), and in the moment when it is clicked it will access the desired page.</td><td class="column-3">2p</td>
</tr><tr class="row-17 odd">
	<td class="column-1">IFB_012</td><td class="column-2">It will contain a log out button it will redirect the user to the LoginView.</td><td class="column-3">3p</td>
</tr><tr class="row-18 even">
	<td class="column-1">IFB_013</td><td class="column-2">The user will have the posibility to search for the users of the application by using a search bar.<br>
The search will be possible by typing the first name or the last name of a user and the results will be displayed dynamically.</td><td class="column-3">5p</td>
</tr><tr class="row-19 odd">
	<td class="column-1">IFB_014</td><td class="column-2">For the first access of the search bar, the results list will be empty.<br>
For the next times it will be displayed a list with the last 5 searches (using a local text file / database).</td><td class="column-3">4p </td>
</tr><tr class="row-20 even">
	<td class="column-1">IFB_015</td><td class="column-2">When selecting a user found as a result for a search, the current user will be redirected to the profile page of the searched user.</td><td class="column-3">3p</td>
</tr><tr class="row-21 odd">
	<td class="column-1"></td><td class="column-2">Profile</td><td class="column-3">16p </td>
</tr><tr class="row-22 even">
	<td class="column-1">IFB_016</td><td class="column-2">The page will contain the next fields: first name, last name, department, office name, team name, floor number, profile picture.</td><td class="column-3">3p</td>
</tr><tr class="row-23 odd">
	<td class="column-1">IFB_017</td><td class="column-2">It will contain a timeline for the current day, divided into hours, where it will be displayed the user's availability.</td><td class="column-3">2p</td>
</tr><tr class="row-24 even">
	<td class="column-1">IFB_018</td><td class="column-2">The user will have the possibility to set an interval of time when he/she is free only for the current day.</td><td class="column-3">2p</td>
</tr><tr class="row-25 odd">
	<td class="column-1">IFB_019</td><td class="column-2">Once an interval is set, the current user will have the possibility to delete or edit it.</td><td class="column-3">4p</td>
</tr><tr class="row-26 even">
	<td class="column-1">IFB_020</td><td class="column-2">If none intervals were set, the timeline will be implicitly marked with RED.</td><td class="column-3">1p</td>
</tr><tr class="row-27 odd">
	<td class="column-1">IFB_021</td><td class="column-2">Once an interval is set, it will be marked with GREEN and the rest of the timeline will remain RED.</td><td class="column-3">1p</td>
</tr><tr class="row-28 even">
	<td class="column-1">IFB_022</td><td class="column-2">It will contain a checkbox (Favorite). When the user A check this checkbox for user B, B will be added in the list of favorite users for A.</td><td class="column-3">3p </td>
</tr><tr class="row-29 odd">
	<td class="column-1"></td><td class="column-2">Send a request</td><td class="column-3">29p </td>
</tr><tr class="row-30 even">
	<td class="column-1">IFB_023</td><td class="column-2">You can send an invitation for a break by filling this fields: invited persons, time interval, place, comment.</td><td class="column-3">3p</td>
</tr><tr class="row-31 odd">
	<td class="column-1">IFB_024</td><td class="column-2">The same invitation can be sent to a larger number of users or to a single user.</td><td class="column-3">1p</td>
</tr><tr class="row-32 even">
	<td class="column-1">IFB_025</td><td class="column-2">The invited person field will contain a button to be able to add guests. <br>
When the button is selected, a new list with all users in alphabetical order and a search bar will open. There will be a checkbox next to each user. The list will also contain a CONTINUE button. <br>
When pressing the CONTINUE button: you will return to the SEND request page and the selected persons will be added to the invited person field.</td><td class="column-3">6p</td>
</tr><tr class="row-33 odd">
	<td class="column-1">IFB_026</td><td class="column-2">At the beginning of the list, the users who have been added as favourites will appear first and they will be marked with a star.<br>
After the last item in the favourites list, the rest of the users will be displayed in alphabetical order.</td><td class="column-3">4p</td>
</tr><tr class="row-34 even">
	<td class="column-1">IFB_027</td><td class="column-2">To modify the guest list:<br>
- the add button will be selected again and the list of users will open<br>
- those who are already invited, have the checkbox ticked<br>
- to remove a guest, deselect the checkbox</td><td class="column-3">2p</td>
</tr><tr class="row-35 odd">
	<td class="column-1">IFB_028</td><td class="column-2">The time interval: <br>
It will be a field form where the user will have the possibility to select multiple time intervals.<br>
The intervals will be proposed based on the availability of each user invited, but the search for free interval will only be done on a date selected from a calendar by the user beforehand.<br>
If there isn't a time interval that will fit all of the participants's timelines, an error message will be displayed saying that there are no free intervals available for all the persons selected.</td><td class="column-3">6p</td>
</tr><tr class="row-36 even">
	<td class="column-1">IFB_029</td><td class="column-2">If there will be added/deleted persons in the meantime, the proposed intervals will be recalculated.</td><td class="column-3">1p</td>
</tr><tr class="row-37 odd">
	<td class="column-1">IFB_030</td><td class="column-2">The mandatory fields will be marked with an asterisk in order to differentiate them. The mandatory fields are: invited persons, time intervals, place.</td><td class="column-3">1p</td>
</tr><tr class="row-38 even">
	<td class="column-1">IFB_031</td><td class="column-2">It will contain a button for sending the invitation.<br>
If the invitation will be successfully sent, an message will be displayed in order to inform the user. The user will be redirected to the Home page.<br>
If there are still mandatory fields not filled in, the invitation will not be sent and an error message will be displayed to notify the user.</td><td class="column-3">4p</td>
</tr><tr class="row-39 odd">
	<td class="column-1">IFB_032</td><td class="column-2">If the BACK button will be clicked, the user will be notified by a pop up that the data will be lost, having the possibility to continue the action or to cancel it.</td><td class="column-3">1p</td>
</tr><tr class="row-40 even">
	<td class="column-1"></td><td class="column-2">Requests view</td><td class="column-3">8p</td>
</tr><tr class="row-41 odd">
	<td class="column-1">IFB_033</td><td class="column-2">This page will contain a list of all requests received by the user.</td><td class="column-3">2p</td>
</tr><tr class="row-42 even">
	<td class="column-1">IFB_034</td><td class="column-2">Each element of the list will contain: the initiator, place, hour, list of participants, comment. </td><td class="column-3">3p</td>
</tr><tr class="row-43 odd">
	<td class="column-1">IFB_035</td><td class="column-2">Each invitation must have 2 options: decline and accept.</td><td class="column-3">1p</td>
</tr><tr class="row-44 even">
	<td class="column-1">IFB_036</td><td class="column-2">For each participant, the current status of the invitation will be shown: <br>
-pending (the invited user didn't respond to the request)<br>
-declined (the invited user declined the request)<br>
-accepted (the invited user accepted the request)</td><td class="column-3">2p</td>
</tr></tbody>
</table></div>

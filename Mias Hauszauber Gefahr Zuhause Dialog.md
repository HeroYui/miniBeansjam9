---
date created: 2023-11-04T21:51:00
date updated: 2023-11-05T00:12:00
tags:
  - GameJam
  - GameIdeas
  - Game
---
# Mias Hauszauber: Gefahr Zuhause!
## Dialog Prefab
---
### Titel:
Aktöre:
Kondition:
0: Erdbeeren sind nice -> null

---
## Prolog
### Titel: Fuchsi ermutigt Mia Part I (Prolog)
Aktöre:Fuchsi, 0;
Rollenspielanweisungen: Fuchsi (monologisiert zu Mia, mitfühlend und ermutigend)
Kondition: Keine/Spiel start auto Dialog
0: Mia, hör mal, wir haben 'ne schwierige Situation, aber du kannst das! Du kannst deine Familie schützen.
0: Deine Eltern müssen als Erste davon erfahren, verstehst du? Schleich dich in ihr Zimmer und weck sie.
0: Aber pass auf, der Einbrecher darf uns nicht sehen. Gemeinsam schaffen wir das, Mia. Los geht's!

---
## Leise Schritte für die Rettung (Akt I)
### Titel: Fuchsi und Mia finden das Bücherregal in einer prekären Situation vor 
Aktöre:Fuchsi,0;Bücherregal,1;
Rollenspielanweisungen: Fuchsi (Verständnisvoll doch drängend); Bücherregal (Erst aufgeregt und erregt von der Vorstellung weiter zu lesen dann aber Bedrückt und Beschämt darüber, dass es Mia und Fuchsi den Weg versperrt, zu schwer ist und einfach nicht abnehmen kann.)
Kondition:Keine/Akt I
1: Hallo Mia, hallo Fuchsi. Schön euch zu sehen. Seit ihr wieder da um die Abenteuer der Froschprinzessin Quarkini weiterzulesen?
0: Liebes Bücherregal, schau mal, wir müssen dringend ins Schlafzimmer unserer Eltern. Kannst du nicht einen kleinen Schritt zur Seite machen, damit wir vorbeikommen?
1: Oh, tut mir leid, Fuchsi. Leider bin ich zu schwer und kann mich nicht bewegen. Ich wollte wirklich abnehmen, aber diese neuen Bücher waren einfach zu verlockend.
0: Wir haben nicht die Zeit dich komplett leerzuräumen. Lass uns einfach deinen Bauch ausräumen. Dann können wir durch dich durchklettern.
1: Das klingt nach einem guten Plan! Geht vorsichtig, und passt auf euch auf! -> Mia und Fuchsi wissen vom Bücherregal=true; Bücher die zu verteilen sind = 17;
0: $BücherDieZuVerteielnSind(17) Bücher müssen ausm Regal verschwinden.

---

### Titel: Eine Spannungsgeladene Begegnung
Aktöre:Fuchsi,0;Steckdose,1;
Rollenspielanweisungen: Fuchsi (Verärgert); Steckdose (Angespannt und etwas wie ein Kokain Junkie.)
Kondition:Keine/Akt I
1: Loooos Kleine steck deine Finger in mich rein. Du wirst den rest deines Lebens an dieses einmalige Erlebnis denken. ~Nihahahaha~
0: Hör nicht auf ihn! Mama sagt, Steckdosen sehen zwar aus wie niedliche Schweineschnauzen von Schweinen die in den Wänden leben. Aber es gibt da keine Schweinchen drinnen und es ist gefährlich die Finger da rein zu stecken. Viel Wichtiger ist doch, es wäre unhöflich. Und was würde nur Prinzessin Quarkini von uns Denken wenn wir uns auf dieses Niveau herablassen würden.

---

## Ein Bücherwurm wäre Praktisch. (Akt II)

### Titel: Bücherregal vs Philosophie
Aktöre:Fuchsi,0;Bücherregal,1;
Rollenspielanweisungen: Fuchsi (Verständnisvoll doch drängend); Bücherregal (Bedrückt und Beschämt darüber, dass es Mia und Fuchsi den Weg versperrt, zu schwer ist und einfach nicht abnehmen kann. Doch jetzt voll vorfreude Leichter zu werden)
Kondition:Akt II && $BücherDieZuVerteielnSind >0
1: Jedes Buch das ihr aus meinem Bauch entfernt hinterlässt ein Loch. Doch es wird nie ganz aus meiner Seele Verschwinden und gibt so platz für neue Erfahrungen. Loslassen ist schwer aber schafft platz für neues.

---

### Titel: Bücherregal vs Philosophie
Aktöre:Fuchsi,0;Bücherregal,1;
Rollenspielanweisungen: Fuchsi (Verständnisvoll doch drängend); Bücherregal (Leicht und beschwingt)
Kondition:Akt II && $BücherDieZuVerteielnSind <=0
1: Aaaah ich fühle mich so Frei. Leicht wie ein leeres Bücherregal.
0: Schnell Mia klettern wir durch das Regal zu Mama und Papa. -> Kapitel: Epilog

---

## Epilog
### Titel: Epilog
Aktöre:Mia,0;Vater,1;
Rollenspielanweisungen: Mia (Heil froh endlich bei ihren Eltern zu sein); Vater (Sonor und Beruhigend)
Kondition:Epilog(Autoplay)
1: Die Polizei hat den Einbrecher dank deiner Hilfe schnappen können, meine kleine Prinzessin. Wir feiern deine Tapferkeit mit einem Eis und einem Tag im Zoo.
0: Au ja mal schauen was die Tiere so zu erzählen haben... -> Credits

---
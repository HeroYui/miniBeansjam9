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
Aktöre:Fuchsi,0;
Kondition:
Rollenspielanweisungen:Fuchsi(Drängend);
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
1: Das klingt nach einem guten Plan! Geht vorsichtig, und passt auf euch auf! -> Mia und Fuchsi wissen vom Bücherregal=true; Bücher die zu verteilen sind = 7;
0: $BücherDieZuVerteielnSind Bücher müssen ausm Regal verschwinden.

---

### Titel: Eine Spannungsgeladene Begegnung
Aktöre:Fuchsi,0;Steckdose,1;
Rollenspielanweisungen: Fuchsi (Verärgert); Steckdose (Angespannt und etwas wie ein Kokain Junkie.)
Kondition:Keine/Akt I
1: Loooos Kleine steck deine Finger in mich rein. Du wirst den rest deines Lebens an dieses einmalige Erlebnis denken. ~Nihahahaha~
0: Hör nicht auf ihn! Mama sagt, Steckdosen sehen zwar aus wie niedliche Schweineschnauzen von Schweinen die in den Wänden leben. Aber es gibt da keine Schweinchen drinnen und es ist gefährlich die Finger da rein zu stecken. Viel Wichtiger ist doch, es wäre unhöflich. Und was würde nur Prinzessin Quarkini von uns Denken wenn wir uns auf dieses Niveau herablassen würden.

---

### Titel: Eine Tür die ihren Job zu ernst nimmt
Aktöre:Fuchsi,0;Tür,1;
Kondition: MitTürGeredet=false
Rollenspielanweisungen: Tür(etwas genervt und empört)
1: Ey, schon mal was von von anklopfen gehört? -> MitTürGeredet=true; Tür geht auf wie normale Tür

---

### Titel: Kissenburg Drama
Aktöre:Fuchsi,0;Sofa,1;
Kondition: Keine/Akt I
Rollenspielanweisungen: Fuchsi(Drängend);Sofa(relaxed aber lässt sich nicht unter kriegen und weiß was es will)
1: ~Hmmm~ Mia es ist aber schon etwas spät um eine Kissenburg aus mir zu bauen.
0: Kissenburgen verteidigen nur gegen Fantasie Drachen. Wir müssen weiter Mama und Papa warnen.

---

### Titel: Die Leiden des Stuhls
Aktöre:Fuchsi,0;Stuhl1,1;
Kondition:Keine/Akt I
Rollenspielanweisungen:Fuchsi(Drängend);Stuhl(säufzend schicksal akzeptierend)
1: Ich bin voll belastet...ständig sitzen Leute auf mir drauf. Vor allem die Glitzersteinchen auf Tante Valentinas Hose lassen mich danach immer so zerdellt aussehen. Etwas wie der Mond.
0: Ich glaube nicht, dass und Knarzi der Stuhl helfen kann zu Mama und Papa zu kommen.

---
### Titel: Beziehungsprobleme
Aktöre:Fuchsi,0;Esstisch,1;Stuhl2,2;
Kondition:Keine/AktI
Rollenspielanweisungen:Fuchsi(Drängend);
0: Seit die Beziehung zwischen Quietschie dem Stuhl und dem Esstisch auseinandergeschoben wurde sind beide Beledigte Leberwürste und Stumm.

---

### Titel:Hinter der Schrankwand
Aktöre:Fuchsi,0;Schrank,1;
Kondition:Keine/AktI
Rollenspielanweisungen:Fuchsi(Drängend);Schrank(Rumpelnd aber Gutmütig)
0: Aaach ja der Schrank ist immer ein gutes Versteck.
1: Verstecken, argh...noch mehr Gerümpel.
0: Nein Schrank heute nicht, wir sind auf wichtiger Mission.

---
## Ein Bücherwurm wäre Praktisch. (Akt II)

### Titel: Bücherregal vs Philosophie
Aktöre:Fuchsi,0;Bücherregal,1;
Rollenspielanweisungen: Fuchsi (Verständnisvoll doch drängend); Bücherregal (Bedrückt und Beschämt darüber, dass es Mia und Fuchsi den Weg versperrt, zu schwer ist und einfach nicht abnehmen kann. Doch jetzt voll vorfreude Leichter zu werden)
Kondition:Akt II && $BücherDieZuVerteielnSind >0
1: Jedes Buch das ihr aus meinem Bauch entfernt hinterlässt ein Loch. Doch es wird nie ganz aus meiner Seele Verschwinden und gibt so platz für neue Erfahrungen. Loslassen ist schwer aber schafft platz für neues.

---

### Titel: Wo kommt das denn her?
Aktöre:Fuchsi,0;Sofa,1;
Kondition: Akt II && SofaBücher=false
Rollenspielanweisungen: Fuchsi(Drängend);Sofa(relaxed aber lässt sich nicht unter kriegen und weiß was es will)
0: Hey, Sofa! Wir müssen Bücher aus dem Regal verstecken, damit der Einbrecher sie nicht sieht.
1: ~Hmmm~ Fuchsi, das ist spannend! Aber bevor wir das machen, die Krümmel pieksen immer so kannst du mal meine ritzen sauber machen?
0: Machen wir während wir die Bücher in deine Ritzen schieben.
0: Oh. Was haben wir denn da? Rex der Stegosaurus, das Reittier von Prinzessin Quarkini. Wie kommt der denn hier hin?
1: ~Hmmm~ ich fühle mich so voll und echt ungemütlich.-> SofaBücher=true;BücherDieZuVerteielnSind-=3;
0: Kein wunder du bist ja auch mit 3 Büchern gefüllt. Keine Angst später Räumen wir die wieder auf. Jetzt fehlen noch $BücherDieZuVerteielnSind Bücher.
1: ~Hmmm~ Das sagt ihr immer.... 

---

### Titel: Unbequemes Sofa
Aktöre:Fuchsi,0;Sofa,1;
Kondition: Akt II && SofaBücher=true
Rollenspielanweisungen: Fuchsi(Drängend);Sofa(relaxed abet etwas betrübt)
1: ~Hmmm~ So unbequem war ich ja noch nie...
0: Kein wunder du bist ja auch mit 3 Büchern gefüllt. Keine Angst später Räumen wir die wieder auf. Jetzt fehlen noch $BücherDieZuVerteielnSind Bücher.

---

### Titel: Stühle sind keine guten Verstecke
Aktöre:Fuchsi,0;Stuhl1,1;
Kondition:Akt II
Rollenspielanweisungen:Fuchsi(Drängend);Stuhl(säufzend schicksal akzeptierend)
0: Kannst du Bücher für uns verstecken Knarzi?
1: Na klar! Aber wehe du pupst mich wieder an!
0: Hmm. Das Buch ist leider immer gut Sichtbar ob auf oder unter dem Stuhl. Kein gutes Versteck.

---

### Titel:Klappe zu Schrank Tot
Aktöre:Fuchsi,0;Schrank,1;
Kondition:Akt II && SchrankBücher=false
Rollenspielanweisungen:Fuchsi(Drängend);Schrank(Rumpelnd aber Gutmütig)
0: Aaach ja der Schrank ist immer ein gutes Versteck.
1: Verstecken, argh...noch mehr Gerümpel.
0: Entschuldige wir stopfen nur schnell ein paar Bücher in dich und machen dann ganz schnell die Tür zu.
1: Ihr macht waaas? Das geht doch ni.......... -> $BücherDieZuVerteielnSind-= 4; SchrankBücher=true
0: Sehr gut. Jetzt fehlen noch $BücherDieZuVerteielnSind Bücher.

---

### Titel: Bergsteigen
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
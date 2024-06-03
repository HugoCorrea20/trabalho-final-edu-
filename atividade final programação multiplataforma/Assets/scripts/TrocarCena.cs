using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public string nomeDaCena;
    public GameObject creditos;
    public GameObject menuprincipal;
    public GameObject introdu��o;
    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject come�arbtn;
    public GameObject proximofalar1btn;
    public GameObject proximofalar2btn;
    public GameObject tutirialJason;
    public GameObject tutirialnavio;
   

    public void TrocarParaCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
    public void SAIR()
    {
        Application.Quit();
        Debug.Log("saiu");
    }
    public void abrircreditos()
    {
        creditos.SetActive(true);
        menuprincipal.SetActive(false);

    }
    public void fecharcreditos()
    {
        creditos.SetActive(false );
        menuprincipal.SetActive(true );
    }
    public void abririntrodu��o()
    {
        menuprincipal.SetActive(false );
        introdu��o.SetActive(true);
        texto1.SetActive(true);
        come�arbtn.SetActive(false);
        come�arbtn.SetActive(true);
    }
    public void falar2()
    {
        texto2.SetActive(true);
        texto1.SetActive(false);
        proximofalar1btn.SetActive(false);
        proximofalar2btn.SetActive(true);
    }
    public void falar3() 
    { 
    texto3 .SetActive(true);
    texto2 .SetActive(false);
    come�arbtn .SetActive(true);
    proximofalar2btn .SetActive(false);
    }
    public void tutorialjason()
    {
        
        tutirialJason.SetActive(true);
        tutirialnavio.SetActive(false);
    }
    public void tutorialnavio()
    {
        tutirialJason.SetActive(false);
        menuprincipal.SetActive (false);
        tutirialnavio.SetActive(true);
    }
    public void sairtutorial()
    {
        tutirialnavio.SetActive(false);
        menuprincipal.SetActive(true);
       tutirialJason .SetActive(false);
    }

}

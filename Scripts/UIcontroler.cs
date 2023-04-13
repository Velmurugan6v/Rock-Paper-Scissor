using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroler : MonoBehaviour
{
    public GameObject player_selected_icon;
    public GameObject cpu_selected_icon;
    public Sprite[] player_selection_s, cpu_selection_s;
    public Image player_seletion_img;
    public Image cpu_seletion_img;
    public int player_point, cpu_point;
    public int remaining_round;
    public Text player_point_text, cpu_point_text;
    public Text remaining_round_text;
    public GameObject point_resolut;
    public Text point_resolut_text;
    public bool player_won, math_die;
    public GameObject player_finelResoult, cpu_finelResoult, math_die_resoult;
    public GameObject[] all_icon;
    public Animator anim;

    public GameObject tie_panel;

    public AudioSource sound_for_sfx;
    public AudioClip click_sfx;

    public GameObject exlore_fx;
    // Start is called before the first frame update
    void Start()
    {
        ResetOfSelectionIcon();
        point_resolut.SetActive(false);
        remaining_round_text.text = FindObjectOfType<GameController>().chance.ToString();
        tie_panel.SetActive(false);
    }

    public void ResetOfSelectionIcon()
    {
        player_selected_icon.SetActive(false);
        cpu_selected_icon.SetActive(false);
    }

    //Player Selection Function
    public void PlayerSeleRock(int sprite_no)
    {
        EnabelPlayerSelec();
        player_seletion_img.sprite = player_selection_s[sprite_no];
    }

    public void PlayerSelePaper(int sprite_no)
    {
        EnabelPlayerSelec();
        player_seletion_img.sprite = player_selection_s[sprite_no];
    }

    public void PlayerSeleScissor(int sprite_no)
    {
        EnabelPlayerSelec();
        player_seletion_img.sprite = player_selection_s[sprite_no];
    }

    public void EnabelPlayerSelec()
    {
        player_selected_icon.SetActive(true);
    }

    public void CPUseleRock(int sprite_no)
    {
        EnableCPUselec();
        cpu_seletion_img.sprite = cpu_selection_s[sprite_no];
    }

    public void CPUselePaper(int sprite_no)
    {
        EnableCPUselec();
        cpu_seletion_img.sprite = cpu_selection_s[sprite_no];
    }

    public void CPUseleScissor(int sprite_no)
    {
        EnableCPUselec();
        cpu_seletion_img.sprite = cpu_selection_s[sprite_no];
    }

    public void EnableCPUselec()
    {
        cpu_selected_icon.SetActive(true);
    }

    //Add Points 
    public void AddPoints(int player,int cpu)
    {
        player_point += player;
        player_point_text.text = player_point.ToString();
        cpu_point += cpu;
        cpu_point_text.text = cpu_point.ToString();
    }

    public void ReduceRound(int no)
    {
        remaining_round -= no;
        remaining_round_text.text = remaining_round.ToString();
    }

    public void FinalResoult()
    {
        if (player_won==true && math_die==false)
        {
            //player_finelResoult.SetActive(true);
            //canvas_anim.Play("player");
        }
        else if (player_won==false && math_die==false)
        {
            //cpu_finelResoult.SetActive(true);
            //canvas_anim.Play("cpu");
        }
        else if (player_won==false && math_die==true)
        {
            //math_die_resoult.SetActive(true);
        }
    }

    public IEnumerator PointResoult(string whoGetPoint)
    {
        point_resolut_text.text = whoGetPoint;
        yield return new WaitForSeconds(1);
        point_resolut.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        ResetOfSelectionIcon();
        point_resolut.SetActive(false);
        EnableOfAllIcon();
    }

    public void EnableOfAllIcon()
    {
        foreach (GameObject icon in all_icon)
        {
            icon.SetActive(true);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Click sound
    }

    //Animation
    public IEnumerator PlayAnimation(string animName)
    {
        yield return new WaitForSeconds(1f);

        if (animName=="PS")
        {
            anim.Play("PS");
        }
        else if (animName == "PR")
        {
            anim.Play("PR");
        }
        else if (animName == "RS")
        {
            anim.Play("RS");
        }
        else if (animName == "RP")
        {
            anim.Play("RP");
        }
        else if (animName == "SR")
        {
            anim.Play("SR");
        }
        else if (animName == "SP")
        {
            anim.Play("SP");
        }
        else if (animName=="Tie")
        {
            anim.Play("Tie");
        }
    }

    public void PlayVFX()
    {
        //print("Play VFX");
        Instantiate(exlore_fx);
    }
    
   public IEnumerator TiePanel()
    {
        yield return new WaitForSeconds(2f);
        tie_panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        tie_panel.SetActive(false);
    }

    public void PlaySfx()
    {
        sound_for_sfx.clip = click_sfx;
        sound_for_sfx.Play();
        print("audioPlayed");
    }
}

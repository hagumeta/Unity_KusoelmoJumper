using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class CameraFocuser : MonoBehaviour
{
    public string TargetTag;
    public float MinSize;
    public float MaxSize;
    public Vector2 Margin;

    private Camera camera;
    private float sizeTo;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var list = new List<GameObject>(GameObject.FindGameObjectsWithTag(this.TargetTag));
        if (list.Count <= 0) return;
        var farestPos = list.OrderBy(a => Vector3.Distance(this.transform.position, a.transform.position)).Last().transform.position;


        var horizen = this.camera.aspect * this.camera.orthographicSize;
        var vertical = this.camera.orthographicSize;

        var hdiff = Mathf.Abs(farestPos.x - this.camera.transform.position.x) + this.Margin.x;
        var hh = Mathf.Clamp(hdiff / this.camera.aspect, this.MinSize, this.MaxSize);

        var vdiff = Mathf.Abs(farestPos.y - this.camera.transform.position.y) + this.Margin.y;
        var vv = Mathf.Clamp(vdiff, this.MinSize, this.MaxSize);

        this.sizeTo = hh >= vv ? hh : vv;
        this.camera.orthographicSize = this.sizeTo;
/*

        DOTween.To(
            () => this.camera.orthographicSize,
            num => this.camera.orthographicSize = num,
            this.sizeTo,
            Time.deltaTime
            ) ;

    */
    }





}

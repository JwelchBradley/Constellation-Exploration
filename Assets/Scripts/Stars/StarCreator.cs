/*****************************************************************************
// File Name :         StarCreator.cs
// Author :            Jacob Welch
// Creation Date :     13 November 2021
//
// Brief Description : Places all of the stars and lines for constellations.
*****************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class StarCreator : MonoBehaviour
{
    public List<Sprite> h;

    #region Fields
    [SerializeField]
    private ConstellationData constellationData;

    #region Star Particles
    /// <summary>
    /// The particles that will be modifed into the stars.
    /// </summary>
    private Particle[] particleStars;

    /// <summary>
    /// The particle system attached to this GameObject. Is used to render stars.
    /// </summary>
    private ParticleSystem ps;

    /// <summary>
    /// The max particles in the particle system (aka the number of stars).
    /// </summary>
    private int maxParticles = 1;

    // new stars_type("", 0.000000f, 0.000000f, 0.000000f),     // The base star data used for any star
    // new stars_type("start", 0, 0, 0),                        // A node for starting a line renderer
    // new stars_type("end", 0, 0, 0),                          // A node for ending a line render
    /// <summary>
    /// The list of stars.
    /// </summary>
    private stars_type[] star_Database = new stars_type[]
    {

        #region Constellations
        #region Monoceros
        new stars_type("Constellation: Monoceros", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("HD 42111", 92.19690734646282f/15, 2.2322596099364223f, 5.72f),
        new stars_type("Epsilon Monocerotis A", 95.98619012265536f/15, 4.31956572704867f, 4.44f),
        new stars_type("Delta Monocerotis", 107.69549661392828f/15, -0.49432014583341904f, 4.13f),
        new stars_type("Zeta Monocerotis", 122.20647818305001f/15, -3.2524658930963595f, 4.5f),
        new stars_type("Alpha Monocerotis", 115.21169497466379f/15, -9.810539180367444f, 4.09f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Delta Monocerotis", 107.69549661392828f/15, -0.49432014583341904f, 4.13f),
        new stars_type("Beta Monocerotis", 97.1737923366634f/15, -7.3089042847096675f, 3.78f),
        new stars_type("Gamma Monocerotis", 93.58666658963283f/15, -6.509878016235419f, 4.13f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Monoceros", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Cancer
        new stars_type("Constellation: Cancer", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Beta Cancri", 124.14421555837424f/15, 8.910002005023488f, 3.66f),
        new stars_type("Asellus Australis", 131.13363619876472f/15, 17.88732391538937f, 4.09f),
        new stars_type("Acubens", 134.68196457037706f/15, 11.58865559669535f, 4.28f),
        new stars_type("Asellus Australis", 131.13363619876472f/15, 17.88732391538937f, 4.09f),
        new stars_type("Asellus Borealis", 130.6793131133835f/15, 21.533331308213242f, 4.66f),
        new stars_type("Iota Cancri", 131.6168274015183f/15, 28.501012576222045f, 4.19f),
        new stars_type("Asellus Borealis", 130.6793131133835f/15, 21.533331308213242f, 4.66f),
        new stars_type("Chi Cancri", 125.08715263844392f/15, 26.94771967642945f, 5.22f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Cancer", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Lynx
        new stars_type("Constellation: Lynx", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Alpha Lyncis", 140.1931860549553f/15, 34.12571529015286f, 3.25f),
        new stars_type("Gaia DR2 810952158347151360", 139.91852977609625f/15, 36.58067923188531f, 3.81f),
        new stars_type("HD 77912", 136.662794656944f/15, 38.17918795419303f, 4.72f),
        new stars_type("10 Ursae Majoris", 135.29374527675967f/15, 41.531778176372896f, 4.03f),
        new stars_type("31 Lyncis", 126.01405593388478f/15, 43.02447921407476f, 4.34f),
        new stars_type("21 Lyncis", 111.9395749488856f/15, 49.00226202061741f, 4.59f),
        new stars_type("15 Lyncis", 104.6969328058022f/15, 58.23177399421105f, 4.5f),
        new stars_type("2 Lyncis", 95.35124662850598f/15, 58.855896883263696f, 4.44f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Lynx", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Cassiopeia
        new stars_type("Constellation: Cassiopeia", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Epsilon Cassiopeiae", 28.697963122437585f/15, 63.39801743709846f, 3.3f),
        new stars_type("Ruchbah", 21.05360913939809f/15, 60.05365872450329f, 2.7f),
        new stars_type("Gamma Cassiopeiae", 14.020618542560772f/15, 60.58449673565951f, 2.13f),
        new stars_type("Shedar", 9.888145544859572f/15, 56.29411432976052f, 2.41f),
        new stars_type("Caph", 2.439093739600238f/15, 58.98844653641294f, 2.34f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Cassiopeia", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Cepheus
        new stars_type("Constellation: Cepheus", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Iota Cephei", 342.0693469911155f/15, 65.9620905185934f, 3.66f),
        new stars_type("Errai", 353.92698135809474f/15, 77.44031337073703f, 3.38f),
        new stars_type("Alfirk", 322.2822340421168f/15, 70.72866054409532f, 3.14f),
        new stars_type("Iota Cephei", 342.0693469911155f/15, 65.9620905185934f, 3.66f),
        new stars_type("Zeta Cephei", 332.9018765252699f/15, 57.94469383952842f, 3.5f),
        new stars_type("Alderamin", 320.04589451180624f/15, 62.38584349705233f, 2.5f),
        new stars_type("Alfirk", 322.2822340421168f/15, 70.72866054409532f, 3.14f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Cepheus", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Ursa Minor
        new stars_type("Constellation: Ursa Minor", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Polaris", 37.91880477260883f/15, 89.01365086819577f, 2.09f),
        new stars_type("Yildun", 258.63593192535916f/15, 86.68194719684152f, 4.34f),
        new stars_type("Epsilon Ursae Minoris", 252.2766405493786f/15, 81.77084641771509f, 4.34f),
        new stars_type("Zeta Ursae Minoris", 235.59754727223412f/15, 77.54117562911266f, 4.28f),
        new stars_type("Kochab", 223.06657850256858f/15, 73.90732432297801f, 2.2f),
        new stars_type("Pherkad", 230.4989136774404f/15, 71.58432627077222f, 3.03f),
        new stars_type("Gaia DR2 1704062466923822336", 243.79752395182084f/15, 75.5204625598323f, 4.81f),
        new stars_type("Zeta Ursae Minoris", 235.59754727223412f/15, 77.54117562911266f, 4.28f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Ursa Minor", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Draco
        new stars_type("Constellation: Draco", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Giausar", 173.310657022197f/15, 69.11510147775475f, 3.91f),
        new stars_type("Kappa Draconis", 188.44250691457572f/15, 69.51524407236813f, 3.83f),
        new stars_type("Thuban", 210.987391329707f/15, 64.10388084550564f, 3.64f),
        new stars_type("Edasich", 231.14508384846363f/15, 58.70993438867198f, 3.45f),
        new stars_type("Theta Draconis", 240.42761393347664f/15, 58.29350515312313f, 4.09f),
        new stars_type("Eta Draconis", 245.4478336986633f/15, 61.46203676930548f, 2.86f),
        new stars_type("Zeta Draconis", 257.16281367241623f/15, 65.4416494610403f, 3.13f),
        new stars_type("Chi Draconis A", 275.68754890316904f/15, 72.48557852145558f, 3.66f),
        new stars_type("Tau Draconis", 288.6937115751851f/15, 73.08571837293385f, 4.59f),
        new stars_type("Epsilon Draconis A", 296.509386270098f/15, 70.0599873291256f, 3.98f),
        new stars_type("Altais", 288.86154412872867f/15, 67.66573016599331f, 3.22f),
        new stars_type("Grumium", 268.4898226279363f/15, 56.607548165251984f, 3.89f),
        new stars_type("Gaia DR2 1420972548150735744", 263.2600223733682f/15, 54.921915708758696f, 4.75f),
        new stars_type("Rastaban", 262.95822720828284f/15, 52.129432413652495f, 2.94f),
        new stars_type("Eltanin", 269.1020541232773f/15, 51.21316904634996f, 2.36f),
        new stars_type("Grumium", 268.4898226279363f/15, 56.607548165251984f, 3.89f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Draco", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Ursa Major
        new stars_type("Constellation: Ursa Major", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Alkaid", 206.8652241908941f/15, 49.50141138787208f, 1.8f),
        new stars_type("Mizar", 200.97112032321377f/15, 54.648981244342885f, 2.25f),
        new stars_type("Alioth", 193.7036182949934f/15, 55.72344300818148f, 1.75f),
        new stars_type("Megrez", 183.5404683739524f/15, 56.817865960774775f, 3.33f),
        new stars_type("Dubhe", 165.49705648644562f/15, 61.88151204929921f, 1.95f),
        new stars_type("23 Ursae Majoris", 143.19443962053694f/15, 62.84281208220044f, 3.72f),
        new stars_type("Muscida", 127.75547639408087f/15, 60.45675985342439f, 3.5f),
        new stars_type("Upsilon Ursae Majoris", 147.97033099694218f/15, 58.78775617905971f, 3.84f),
        new stars_type("Phi Ursae Majoris", 148.2544300594076f/15, 53.82240517276641f, 4.56f),
        new stars_type("Merak", 165.0989240997213f/15, 56.236145202767396f, 2.34f),
        new stars_type("Phecda", 178.16464093548726f/15, 53.515187958676044f, 2.42f),
        new stars_type("Megrez", 183.5404683739524f/15, 56.817865960774775f, 3.33f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Dubhe", 165.49705648644562f/15, 61.88151204929921f, 1.95f),
        new stars_type("Merak", 165.0989240997213f/15, 56.236145202767396f, 2.34f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        // Phi Ursae Majoris
        new stars_type("Theta Ursae Majoris", 143.04156200363403f/15, 51.42164160705109f, 3.27f),
        new stars_type("Iota Ursae Majoris A", 135.17941734659564f/15, 47.96815895082547f, 3.19f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Phi Ursae Majoris", 148.2544300594076f/15, 53.82240517276641f, 4.56f),
        new stars_type("Kappa Ursae Majoris", 136.1971877025014f/15, 46.98449292694811f, 3.56f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Phecda", 178.16464093548726f/15, 53.515187958676044f, 2.42f),
        new stars_type("Chi Ursae Majoris", 176.40150572190103f/15, 47.518753821166555f, 3.84f),
        new stars_type("Psi Ursae Majoris", 167.5580409606469f/15, 44.25679920778913f, 3.16f),
        new stars_type("Tania Borealis", 154.217444947029f/15, 42.646429749314315f, 3.45f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Psi Ursae Majoris", 167.5580409606469f/15, 44.25679920778913f, 3.16f),
        new stars_type("Tania Australis", 155.59206181792223f/15, 41.233935481148826f, 3.14f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Ursa Major", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Leo
        new stars_type("Constellation: Leo", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Denebola", 177.19509280927602f/15, 14.302682154892556f, 2.16f),
        new stars_type("Zosma", 168.5322492824517f/15, 20.2561129969137f, 2.58f),
        new stars_type("Algieba", 155.17986869367303f/15, 19.6269496960207f, 2.16f),
        new stars_type("Eta Leonis", 151.8898995225003f/15, 16.982314876508315f, 3.5f),
        new stars_type("Regulus", 152.08032880872216f/15, 11.69392211574427f, 1.32f),
        new stars_type("Chertan", 168.49072587088142f/15, 15.160494405941233f, 3.33f),
        new stars_type("Denebola", 177.19509280927602f/15, 14.302682154892556f, 2.16f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Algieba", 155.17986869367303f/15, 19.6269496960207f, 2.16f),
        new stars_type("Adhafera", 154.15901941541094f/15, 23.149051164007922f, 3.5f),
        new stars_type("Rasalas", 148.18711558564178f/15, 25.736546109223926f, 4.03f),
        new stars_type("Epsilon Leonis", 146.5577253497758f/15, 23.515253584628432f, 3.11f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Leo", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Hydra
        new stars_type("Constellation: Hydra", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Gamma Hydrae", 199.72626123882728f/15, -23.447195412739838f, 3.14f),
        new stars_type("Psi Hydrae", 197.29394226998514f/15, -23.38051803678649f, 5.09f),
        new stars_type("Beta Hydrae", 177.93259153878418f/15, -33.83610668134197f, 4.25f),
        new stars_type("Xi Hydrae", 173.34238110933626f/15, -32.118202991329f, 3.69f),
        new stars_type("Nu Hydrae", 10.8333f, -16.885908969522355f, 3.27f),
        new stars_type("Mu Hydrae", 10.45f, -16.885908969522355f, 3.95f),
        new stars_type("Lambda Hydrae", 152.54391586506705f/15, -12.613076862369537f, 3.77f),
        new stars_type("Upsilon1 Hydrae", 148.06108730226876f/15, -15.050907771206113f, 4.25f),
        new stars_type("Alphard", 141.6326341715307f/15, -8.726060184314672f, 2.13f),
        new stars_type("Tau1 Hydrae", 142.3432326794269f/15, -3.038732346795514f, 4.69f),
        new stars_type("Tau2 Hydrae", 143.0266490277169f/15, -1.4552322506163515f, 4.56f),
        new stars_type("Gaia DR2 3845263368043086080", 138.56754500599897f/15, 2.039618334873929f, 3.78f),
        new stars_type("Hydrobius", 133.6012889354514f/15, 6.000639310179181f, 3.27f),
        new stars_type("Rho Hydrae", 132.14383392277534f/15, 5.563766398666189f, 4.34f),
        new stars_type("Epsilon Hydrae", 131.70316477060922f/15, 6.143364553656558f, 3.5f),
        new stars_type("Delta Hydrae", 129.4405982579885f/15, 5.431251264539173f, 4.13f),
        new stars_type("Sigma Hydrae", 129.62537881206302f/15, 3.0714006945356296f, 4.59f),
        new stars_type("Eta Hydrae", 130.67947378090062f/15, 3.275799593682532f, 4.22f),
        new stars_type("Rho Hydrae", 132.14383392277534f/15, 5.563766398666189f, 4.34f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Hydra", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Crater
        new stars_type("Constellation: Crater", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Gamma Crateris", 171.24613601082999f/15, -17.946390757441133f, 4.13f),
        new stars_type("Zeta Crateris", 176.21803752632414f/15, -18.626517491773843f, 4.88f),
        new stars_type("Eta Crateris", 179.09436721034245f/15, -17.413286182547544f, 5.16f),
        new stars_type("Theta Crateris", 173.93665455624404f/15, -9.95440359837123f, 4.66f),
        new stars_type("Epsilon Crateris", 171.1965028328635f/15, -11.12557062236658f, 4.91f),
        new stars_type("Delta Crateris", 169.96979365318197f/15, -15.004947578166075f, 3.7f),
        new stars_type("Gamma Crateris", 171.24613601082999f/15, -17.946390757441133f, 4.13f),
        new stars_type("Beta Crateris", 167.75719695391516f/15, -23.063161002663943f, 4.47f),
        new stars_type("Alkes", 164.99100818844983f/15, -18.559701620718517f, 4.22f),
        new stars_type("Delta Crateris", 169.96979365318197f/15, -15.004947578166075f, 3.7f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Crater", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Virgo
        new stars_type("Constellation: Virgo", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("107 Virginis", 220.69051452311533f/15, -5.925518662902277f, 3.95f),
        new stars_type("Syrma", 214.07534373276255f/15, -6.2696352333723535f, 4.16f),
        new stars_type("Kappa Virginis", 213.4562997311474f/15, -10.236631461780373f, 4.31f),
        new stars_type("Spica", 201.25986132540092f/15, -11.431025764101767f, 0.89f),
        new stars_type("Porrima", 190.45606777890924f/15, -1.720125013192192f, 2.81f),
        new stars_type("Delta Virginis", 193.84488642031917f/15, 3.1287280494737817f, 3.44f),
        new stars_type("Heze", 203.7975139479625f/15, -0.8412269841749616f, 3.41f),
        new stars_type("Spica", 201.25986132540092f/15, -11.431025764101767f, 0.89f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Heze", 203.7975139479625f/15, -0.8412269841749616f, 3.41f),
        new stars_type("Tau Virginis", 210.47746731677267f/15, 1.2768995852255178f, 4.25f),
        new stars_type("109 Virginis", 221.65963315877724f/15, 1.6334413776390175f, 3.72f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Vindemiatrix", 195.63461180711192f/15, 10.70973470082895f, 2.98f),
        new stars_type("Delta Virginis", 193.84488642031917f/15, 3.1287280494737817f, 3.44f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Porrima", 190.45606777890924f/15, -1.720125013192192f, 2.81f),
        new stars_type("Zaniah", 184.9204393705785f/15, -0.9389442974519957f, 3.89f),
        new stars_type("3 Virginis", 176.4989904718185f/15, 6.2607264316686395f, 4.13f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Virgo", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Bootes
        new stars_type("Constellation: Bootes", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Upsilon Boötis", 207.2606699579641f/15, 15.544195606824445f, 4.16f),
        new stars_type("Muphrid", 208.6610657118442f/15, 18.373542033758895f, 2.78f),
        new stars_type("Arcturus", 213.9232661598607f/15, 19.151248074737953f, 0.11f),
        new stars_type("Rho Boötis", 218.15493383825844f/15, 30.15398786030632f, 3.72f),
        new stars_type("Seginus", 218.0132563901324f/15, 38.297098875726064f, 3.09f),
        new stars_type("Nekkar", 225.51752384561806f/15, 40.39176091074834f, 3.64f),
        new stars_type("Delta Bootis", 228.869414304444f/15, 33.296147538559936f, 3.63f),
        new stars_type("Gaia DR2 1279798794195721600", 221.26500007296363f/15, 27.060127566630076f, 1.94f),
        new stars_type("Arcturus", 213.9232661598607f/15, 19.151248074737953f, 0.11f),
        new stars_type("Zeta Boötis", 220.30224803100438f/15, 13.750764573404323f, 3.8f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Bootes", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Hercules
        new stars_type("Constellation: Hercules", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Chi Herculis", 238.19165983091617f/15, 42.431684588180616f, 4.72f),
        new stars_type("Gaia DR2 1385978666451134208", 244.92116471914505f/15, 46.3054914269016f, 3.78f),
        new stars_type("Sigma Herculis", 248.5277493994588f/15, 42.41131265012725f, 4.19f),
        new stars_type("Eta Herculis", 250.72693337237368f/15, 38.89425467184441f, 3.64f),
        new stars_type("Zeta Herculis", 250.32459955103283f/15, 31.592903598772203f, 2.92f),
        new stars_type("Epsilon Herculis", 255.0643906758992f/15, 30.90739388435055f, 3.91f),
        new stars_type("Pi Herculis", 258.7653423928312f/15, 36.80224275562656f, 3.3f),
        new stars_type("Eta Herculis", 250.72693337237368f/15, 38.89425467184441f, 3.64f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Epsilon Herculis", 255.0643906758992f/15, 30.90739388435055f, 3.91f),
        new stars_type("Maasym", 262.68167594592796f/15, 26.08550627203768f, 4.53f),
        new stars_type("Mu1 Herculis", 266.72556545035985f/15, 27.481905993262224f, 3.55f),
        new stars_type("92 Herculis", 269.45011533677564f/15, 29.226340733753876f, 3.84f),
        new stars_type("Omicron Herculis", 271.90311567566465f/15, 28.742398054374977f, 3.83f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Pi Herculis", 258.7653423928312f/15, 36.80224275562656f, 3.3f),
        new stars_type("69 Herculis", 259.4230844463335f/15, 37.266874038043596f, 4.63f),
        new stars_type("Rho Herculis", 260.9256253375674f/15, 37.11917524868433f, 4.13f),
        new stars_type("Theta Herculis", 269.0638510022074f/15, 37.22483104697543f, 4f),
        new stars_type("Iota Herculis", 264.8523454850293f/15, 45.983622183152406f, 3.73f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Maasym", 262.68167594592796f/15, 26.08550627203768f, 4.53f),
        new stars_type("sarin", 258.7590128552133f/15, 24.813382545314532f, 3.14f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Zeta Herculis", 250.32459955103283f/15, 31.592903598772203f, 2.92f),
        new stars_type("Kornephoros", 247.55551464223282f/15, 21.468415732464933f, 2.94f),
        new stars_type("Gamma Herculis", 245.49227129515808f/15, 19.137229654970113f, 3.81f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Hercules", 0.000000f, 0.000000f, 0.000000f),
        #endregion
  
        #region Orion
        new stars_type("Constellation: Orion", 0.000000f, 0.000000f, 0.000000f),
        #region Torso
        // Orion torso 0-7 indexes
        new stars_type("start", 0, 0, 0),
        new stars_type("Betelgeuse", 5.919500f, 7.243773685353041f, 0.500000f),
        new stars_type("Meissa", 5.583333f, 9.560000f, 3.300000f),
        new stars_type("Bellatrix", 5.418851f, 6.349702f, 1.640000f),
        new stars_type("Mintaka", 5.533445f, -0.299092f, 2.250000f),
        new stars_type("Alnilam", 5.603559f, -1.20192f, 1.690000f),
        new stars_type("Alnitak", 5.679313f, -1.942572f, 1.740000f),
        new stars_type("Betelgeuse", 5.919500f, 7.243773685353041f, 0.500000f),
        new stars_type("end", 0, 0, 0),
        #endregion

        #region Up Arm
        // Orion Up Arm 9-16 indexes
        new stars_type("start", 0, 0, 0),
        new stars_type("Betelgeuse", 5.919500f, 7.243773685353041f, 0.500000f),
        new stars_type("Mu Orionis", 90.81583987857081f/15, 9.530229476781042f, 4.16f),
        new stars_type("Xi Orionis", 93.24749286638966f/15, 14.100099175230447f, 4.38f),
        new stars_type("64 Orionis", 91.04442726234083f/15, 19.830121936059367f, 5.09f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Xi Orionis", 6.216666f, 14.120900f, 4.38f),
        new stars_type("Nu Orionis", 92.02701737861587f/15, 14.62005495583628f, 4.34f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Mu Orionis", 90.81583987857081f/15, 9.530229476781042f, 4.16f),
        new stars_type("Nu Orionis", 92.02701737861587f/15, 14.62005495583628f, 4.34f),
        new stars_type("Chi Orionis", 5.916600f, 20.164610f, 4.50f),
        new stars_type("end", 0, 0, 0),
        #endregion

        #region Box Arm
        new stars_type("start", 0, 0, 0),
        new stars_type("Bellatrix", 5.418851f, 6.349702f, 1.640000f),
        new stars_type("PI^3 Orionis", 72.58677163058913f/15, 6.713162919257889f, 3.28f),
        new stars_type("PI^2 Orionis", 72.80704102028638f/15, 8.770450922740736f, 4.34f),
        new stars_type("PI^1 Orionis", 73.52495589495844f/15, 10.002482196142342f, 4.740000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("PI^3 Orionis", 72.58677163058913f/15, 6.713162919257889f, 3.28f),
        new stars_type("PI^4 Orionis", 72.8190242880102f/15, 5.335948790127093f, 3.61f),
        new stars_type("PI^5 Orionis", 73.48167330848129f/15, 2.6963509720090943f, 3.64f),
        new stars_type("PI^6 Orionis", 74.57496766386038f/15, 1.4505505846306124f, 4.62f),
        new stars_type("end", 0, 0, 0),
        #endregion

        #region Lower Body
        // Orion Lower Body
        new stars_type("start", 0, 0, 0),
        new stars_type("Mintaka", 5.533445f, -0.299092f, 2.250000f),
        new stars_type("Alnilam", 5.603559f, -1.20192f, 1.690000f),
        new stars_type("Alnitak", 5.679313f, -1.942572f, 1.740000f),
        new stars_type("Saiph", 5.795941f, -9.669605f, 2.07000f),
        new stars_type("Rigel", 5.242300f, -8.201700f, 0.120000f),
        new stars_type("Mintaka", 5.533445f, -0.299092f, 2.250000f),
        new stars_type("end", 0, 0, 0),
        #endregion
        new stars_type("Constellation: Orion", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Gemini
        new stars_type("Constellation: Gemini", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("1 Geminorum", 90.96828975357269f/15, 22.991653600620577f, 4.31f),
        new stars_type("Propus", 93.4369219411265f/15, 22.60247193995005f, 3.28f),
        new stars_type("Tejat", 95.98773443674125f/15, 22.356343965590995f, 2.91f),
        new stars_type("Mebsuta", 101.10562608637606f/15, 24.87886180185512f, 3.19f),
        new stars_type("Tau Geminorum", 107.87149066662214f/15, 30.160378254773047f, 4.53f),
        new stars_type("Iota Geminorum", 111.51082460443274f/15, 27.53100911040583f, 3.94f),
        new stars_type("Upsilon Geminorum", 114.1317257137815f/15, 26.655942385766544f, 4.16f),
        new stars_type("Wasat", 110.00409175329717f/15, 21.706662711709033f, 3.59f),
        new stars_type("Mekbuda", 106.04571780422269f/15, 20.29783595770087f, 4.16f),
        new stars_type("Alhena", 99.15054509766834f/15, 16.34484748237026f, 1.92f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Nu Geminorum", 90.76460922102582f/15, 27.337930559242455f, 4.09f),
        new stars_type("Mebsuta", 101.10562608637606f/15, 24.87886180185512f, 3.19f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Theta Geminorum", 103.18446664250823f/15, 33.68578499485399f, 3.63f),
        new stars_type("Tau Geminorum", 107.87149066662214f/15, 30.160378254773047f, 4.53f),
        new stars_type("Castor", 113.658355403213f/15, 31.610478805878525f, 1.58f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Pollux", 116.2065438829245f/15, 27.769179905166133f, 1.29f),
        new stars_type("Upsilon Geminorum", 114.1317257137815f/15, 26.655942385766544f, 4.16f),
        new stars_type("Kappa Geminorum", 116.2195504199731f/15, 24.147113064950293f, 3.72f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Xi Geminorum", 101.26134656822293f/15, 12.625353338104633f, 3.44f),
        new stars_type("Lambda Geminorum A", 109.24057067532596f/15, 16.563537747132038f, 3.61f),
        new stars_type("Wasat", 110.00409175329717f/15, 21.706662711709033f, 3.59f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Gemini", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Auriga
        new stars_type("Constellation: Auriga", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Menkalinan", 90.24228333908634f/15, 44.98095102469142f, 1.90f),
        new stars_type("Capella", 79.14364079496094f/15, 45.71962374693095f, 0.24f),
        new stars_type("Zeta Aurigae", 75.59610120911057f/15, 40.80211121783874f, 3.84f),
        new stars_type("Hassaleh", 74.00332027893697f/15, 32.983075382685826f, 2.83f),
        new stars_type("Elnath", 81.57083529450648f/15, 28.641781623968633f, 1.61f),
        new stars_type("Theta Aurigae", 90.00015170587346f/15, 37.17078761795807f, 2.61f),
        new stars_type("Menkalinan", 90.24228333908634f/15, 44.98095102469142f, 1.90f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Auriga", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Taurus
        new stars_type("Constellation: Taurus", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Elnath", 81.57083529450648f/15, 28.641781623968633f, 1.61f),
        new stars_type("Tau Tauri", 70.7307662104994f/15, 22.730374363246664f, 4.22f),
        new stars_type("Ain", 66.9641033230681f/15, 18.997222141099066f, 3.69f),
        new stars_type("Aldebaran", 69.01801469499635f/15, 16.23411618843057f, 1.00f),
        new stars_type("Theta1 Tauri", 67.16864749026514f/15, 15.686429292514367f, 4.00f),
        new stars_type("Theta2 Tauri", 67.36450513117276f/15, 15.77115967368875f, 3.45f),
        new stars_type("Gamma Tauri", 65.05871186308119f/15, 15.374621742949984f, 3.80f),
        new stars_type("Delta Tauri", 65.48336868603155f/15, 17.676407965779113f, 3.92f),
        new stars_type("Delta3 Tauri A", 66.3543892058143f/15, 17.651605224364197f, 4.31f),
        new stars_type("Ain", 66.9641033230681f/15, 18.997222141099066f, 3.69f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Delta Tauri", 65.48336868603155f/15, 17.676407965779113f, 3.92f),
        new stars_type("Pleiades", 56.888193674042256f/15, 24.045970935572253f, 1.59f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Aldebaran", 69.01801469499635f/15, 16.23411618843057f, 1.00f),
        new stars_type("Zeta Tauri", 84.40509021913617f/15, 20.868944902381596f, 2.91f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Gamma Tauri", 65.05871186308119f/15, 15.374621742949984f, 3.80f),
        new stars_type("Lambda Tauri", 60.42993339045191f/15, 12.459584850322635f, 3.38f),
        new stars_type("Omicron Tauri", 51.13842206766417f/15, 8.781337495766852f, 3.77f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Taurus", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Perseus
        new stars_type("Constellation: Perseus", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Miram", 42.224965619464264f/15, 56.01172427262863f, 3.89f),
        new stars_type("Gamma Persei", 45.75614659900449f/15, 53.43858663918914f, 3.05f),
        new stars_type("Mirfak", 50.92279149212425f/15, 49.60333434834531f, 1.89f),
        new stars_type("Delta Persei", 55.632024894592824f/15, 47.70524536439001f, 2.97f),
        new stars_type("Epsilon Persei", 59.45970650843326f/15, 39.73453040143972f, 2.83f),
        new stars_type("Menkib", 59.56279936581256f/15, 35.793576915725005f, 4.00f),
        new stars_type("Zeta Persei", 58.21889712447938f/15, 31.959757150141655f, 2.89f),
        new stars_type("Omicron Persei A", 55.756929776761055f/15, 32.31726250371995f, 3.84f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Mirfak", 50.92279149212425f/15, 49.60333434834531f, 1.89f),
        new stars_type("Algol", 46.82404733691389f/15, 40.73536995582118f, 2.09f),
        new stars_type("Rho Persei", 46.32364598795892f/15, 38.5633139217738f, 3.28f),
        new stars_type("16 Persei", 42.683207012298595f/15, 38.0457601625787f, 4.28f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Perseus", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Canis Major
        new stars_type("Constellation: Canis Major", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Furud", 95.0699873459228f/15, -30.070494995078782f, 2.94f),
        new stars_type("Adhara", 104.65666264753602f/15, -28.984206388901995f, 1.41f),
        new stars_type("Sigma Canis Majoris", 105.43372021675086f/15, -27.948063491407883f, 3.58f),
        new stars_type("Wezen", 107.09754370369312f/15, -26.405481399501394f, 1.96f),
        new stars_type("Omicron2 Canis Majoris", 105.76692241803752f/15, -23.83871783083207f, 3.00f),
        new stars_type("Sirius", 101.29298121878419f/15, -16.73173035325023f, -1.09f),
        new stars_type("Nu2 Canis Majoris", 6.6410375f, -19.1f, 4.09f),
        new stars_type("Omicron1 Canis Majoris", 103.3638095948367f/15, -23.963234167211393f, 4.00f),
        new stars_type("Sigma Canis Majoris", 105.43372021675086f/15, -27.948063491407883f, 3.58f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Adhara", 104.65666264753602f/15, -28.984206388901995f, 1.41f),
        new stars_type("Kappa Canis Majoris", 102.46553753412348f/15, -32.5213051159513f, 3.45f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Wezen", 107.09754370369312f/15, -26.405481399501394f, 1.96f),
        new stars_type("Omega Canis Majoris", 108.70475068167542f/15, -26.78419870433944f, 3.98f),
        new stars_type("Aludra", 7.4576f, -29.315622822888f, 2.41f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Sirius", 101.29298121878419f/15, -16.73173035325023f, -1.09f),
        new stars_type("Iota Canis Majoris", 104.04042466206376f/15, -17.055736823451117f, 4.34f),
        new stars_type("Muliphein", 105.9399123435681f/15, -15.647117188756015f, 4.06f),
        new stars_type("Theta Canis Majoris", 103.5551708210549f/15, -12.048546210514285f, 4.19f),
        new stars_type("Iota Canis Majoris", 104.04042466206376f/15, -17.055736823451117f, 4.34f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Xi2 Canis Majoris", 98.76881136081414f/15, -22.977069367245676f, 4.53f),
        new stars_type("Nu2 Canis Majoris", 6.6410375f, -19.1f, 4.09f),
        new stars_type("Mirzam", 95.68226550714893f/15, -17.96659494336557f, 1.89f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Canis Major", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region TODO
        
        #region Maybes


        #region Cameloparalis

        #endregion

        #region Corvus

        #endregion

        #region Corona Borealis

        #endregion
        #endregion

        #endregion
        #endregion

        #region Not Done
        /*
        new stars_type("Sirius", 6.752500f, -16.716101f, -1.460000f, 0.000000f),
        new stars_type("Canopus", 6.399200f, -52.695801f, -0.720000f, 0.150000f)
        */
        /*
        new stars_type("Sigma Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Eta Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Pi3 Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("42 Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("CVSO 30", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Chi3 Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Nu Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Tau", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("U Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Theta1 Orionis C", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("Theta2 Orionis", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        new stars_type("", 0.000000f, 0.000000f, 0.000000f, 0.000000f),
        */
        #endregion

        #region Stars
        new stars_type("Gaia DR2 1344503094987064192", 268.3152372087703f/15, 39.99661037870184f, 4.75f),
        new stars_type("HD 167965", 273.90308585363925f/15, 42.14800113198965f, 5.5f),
        new stars_type("Alathfar", 276.0732369891015f/15, 39.50660397472807f, 5.13f),
        new stars_type("Gaia DR2 2112785156971655168", 274.2721174071517f/15, 40.925146484602266f, 5.81f),
        new stars_type("Vega", 279.23090140207887f/15, 38.77493571907557f, 0.09f),
        new stars_type("Epsilon² Lyrae", 281.0949541298853f/15, 39.61293241826713f, 4.63f),
        new stars_type("Epsilon¹ Lyrae", 281.10035331794995f/15, 39.66383958684523f, 4.72f),
        new stars_type("13 Lyrae", 283.83473895621853f/15, 43.94558915405615f, 3.92f),
        new stars_type("HD 166208", 271.88785699877667f/15, 43.4604858256423f, 5.13f),
        new stars_type("HD 169305", 275.40329602276f/15, 49.1236186577266f, 5.09f),
        new stars_type("Kappa Lyrae", 274.96715000692575f/15, 36.05380797830205f, 4.47f),
        new stars_type("HD 166640", 272.49419008070214f/15, 36.456156501309806f, 5.72f),
        new stars_type("HD 166229", 271.9979257717301f/15, 36.39174768336908f, 5.66f),
        new stars_type("72 Herculis", 260.1533577416683f/15, 32.45604239305042f, 5.5f),
        new stars_type("68 Herculis", 259.3280922653458f/15, 33.0919219661106f, 4.72f),
        new stars_type("HD 158974", 262.7235007962776f/15, 31.151644741521537f, 5.78f),
        new stars_type("78 Herculis", 262.94879541756325f/15, 28.39818753865033f, 5.66f),
        new stars_type("HD 162555", 267.6082703889487f/15, 29.315640628763887f, 5.66f),
        new stars_type("HD 159501", 263.2838059896309f/15, 41.229904524439604f, 5.88f),
        new stars_type("V819 Herculis", 260.4318000640739f/15, 39.97440141709664f, 5.66f),
        new stars_type("c Herculis", 257.01372901545807f/15, 35.9312805853345f, 5.47f),
        new stars_type("d Herculis", 255.40655714200687f/15, 33.55798125454932f, 5.28f),
        new stars_type("53 Herculis", 253.242891069018f/15, 31.69508700749927f, 5.41f),
        new stars_type("51 Herculis", 252.9361700818224f/15, 24.64502747681031f, 5.19f),
        new stars_type("HD 151203", 251.33634578976213f/15, 15.733820088378769f, 5.63f),
        new stars_type("s Herculis", 252.97493513725718f/15, 14.92918186142607f, 5.38f),
        new stars_type("54 Herculis", 253.84179183853973f/15, 18.432594133760578f, 5.47f),
        new stars_type("Cujam", 246.3614159973865f/15, 14.033305930532608f, 4.56f),
        new stars_type("Gaia DR2 1199629656205894656", 240.33682530598085f/15, 17.69511140076711f, 4.78f),
        new stars_type("Gaia DR2 4450016100717738880", 242.2559670385032f/15, 6.248832259477622f, 5.63f),
        new stars_type("9 Herculis", 243.31217491326683f/15, 5.010808347253611f, 5.59f),
        new stars_type("Lambda Serpentis", 236.47716074088623f/15, 7.392634915619315f, 4.53f),
        new stars_type("QY Serpentis", 238.62146975769897f/15, 20.173949902394828f, 5.53f),
        new stars_type("Pi Serpentis", 240.6189254660213f/15, 22.676061157479694f, 4.84f),
        new stars_type("Rho Serpentis", 237.75237906476727f/15, 20.88199808216554f, 4.84f),
        new stars_type("Iota Serpentis", 235.43700774237809f/15, 19.548125673060433f, 4.53f),
        new stars_type("Xi Coronae Borealis", 245.46522195479108f/15, 30.765787881026572f, 5.00f),
        new stars_type("HIP 79607", 243.75648379861917f/15, 33.75377375523926f, 5.34f),
        new stars_type("Gaia DR2 1378163509598334592", 242.27131664217956f/15, 36.35641807228403f, 4.38f),
        new stars_type("Nu¹ Coronae Borealis", 245.54211241469574f/15, 33.6705124920786f, 5.28f),
        new stars_type("Nu² Coronae Borealis", 245.48648278703698f/15, 33.63441693727263f, 5.50f),
        new stars_type("G Herculis", 247.1819578010401f/15, 41.74703041701869f, 4.47f),
        new stars_type("Kappa Coronae Borealis", 237.64824040883255f/15, 35.697846450949214f, 4.94f),
        new stars_type("Zeta Coronae Borealis A", 234.9610988847756f/15, 36.54101065983761f, 4.59f),
        new stars_type("Alkalurops", 231.13647814363736f/15, 37.240340127825604f, 4.38f),
        new stars_type("Nu² Boötis", 225.11464778598358f/15, 54.04932374987169f, 5.00f),
        new stars_type("Upsilon Herculis", 240.85491940632696f/15, 45.94902650947589f, 4.69f),
        new stars_type("17 Draconis", 249.07465805101816f/15, 52.78759269065261f, 5.06f),
        new stars_type("HD 151613", 251.42627860097102f/15, 56.659686054589464f, 4.91f),
        new stars_type("Gaia DR2 1439121018358632832", 263.7882738148962f/15, 61.73602818997985f, 4.97f),
        new stars_type("HD 161693", 265.8415876192231f/15, 53.69960636489281f, 5.75f),
        new stars_type("36 Draconis", 273.5469138614389f/15, 64.26228950776952f, 5.06f),
        new stars_type("Phi Draconis", 275.3389884756614f/15, 71.21792774030817f, 4.19f),
        new stars_type("42 Draconis", 276.77273137207715f/15, 65.49654054213416f, 4.97f),
        new stars_type("Upsilon Draconis", 283.5439986503635f/15, 71.16831604536544f, 4.97f),
        new stars_type("Sigma Draconis", 292.92485058084065f/15, 69.53086840873317f, 4.78f),
        new stars_type("HIP 86201", 264.19630976647625f/15, 68.62160128015817f, 4.84f),
        new stars_type("27 Draconis", 262.8355829049771f/15, 68.01448856587075f, 5.22f),
        new stars_type("HD 175535", 283.29766407005314f/15, 50.57377834144722f, 5.06f),
        new stars_type("Gaia DR2 2146204847257954944", 283.08608227584085f/15, 52.907460959779684f, 5.25f),
        new stars_type("46 Draconis", 280.8926863507071f/15, 55.50360211593508f, 5.00f),
        new stars_type("45 Draconis", 278.0673417384433f/15, 56.92269960766701f, 4.88f),
        new stars_type("B draconis A", 276.000217768645f/15, 58.66786942666618f, 5.00f),
        new stars_type("Omicron Draconis", 282.7921693039194f/15, 59.25503968130755f, 4.78f),
        new stars_type("Kappa Cygni", 289.3901920257318f/15, 53.253175870699934f, 3.94f),
        new stars_type("Iota Cygni", 292.35067006647193f/15, 51.60043389005253f, 3.81f),
        new stars_type("Theta Cygni", 294.04025541942167f/15, 50.20253696372748f, 4.56f),
        new stars_type("Gaia DR2 2089092884718210432", 298.9112064394896f/15, 52.30146651655213f, 4.91f),
        new stars_type("Pi Draconis", 290.4301585283211f/15, 65.71107274827479f, 4.59f),
        new stars_type("20 Cygni", 297.7336184563705f/15, 52.86836935814548f, 5.16f),
        new stars_type("33 Cygni", 303.3360381173769f/15, 56.43045577380786f, 4.31f),
        new stars_type("Eta Cephei", 311.24985783774696f/15, 61.71165710805913f, 3.56f),
        new stars_type("HD 198084", 311.28571422777236f/15, 57.458361353369234f, 4.63f),
        new stars_type("Theta Cephei", 307.38988545223356f/15, 62.85821039703504f, 4.25f),
        new stars_type("44 Bootis", 225.9707868489205f/15, 47.53217646376237f, 4.88f),
        new stars_type("Gaia DR2 1211957655452767744", 227.94876454750369f/15, 18.85712191244376f, 4.5f),
        new stars_type("Xi Boötis A", 222.88060285211495f/15, 18.965342768088554f, 4.41f),
        new stars_type("Omicron Boötis", 221.35900956342763f/15, 16.83601976937865f, 4.75f),
        new stars_type("Gaia DR2 1186417202929115008", 221.57272369822743f/15, 15.013727655606658f, 3.86f),
        new stars_type("Pi¹ Boötis", 220.0920373526073f/15, 16.321981095033657f, 4.5f),
        new stars_type("Theta Bootis", 216.38172624592616f/15, 51.72294669052349f, 4.12f),
        new stars_type("Lambda Bootis", 214.1057405378612f/15, 45.954530125271376f, 4.19f),
        new stars_type("83 Ursae Majoris", 205.3174260120286f/15, 54.58836082702197f, 4.69f),
        new stars_type("25 Canum Venaticorum A", 204.36858232664616f/15, 36.16212675874071f, 4.84f),
        new stars_type("AW Canum Venaticorum", 208.01019467615401f/15, 34.33529818235968f, 4.78f),
        new stars_type("BH Canum Venaticorum", 203.6340454916778f/15, 37.070642953941984f, 5.00f),
        new stars_type("20 Canum Venaticorum", 199.36293399661406f/15, 40.444043131775985f, 4.78f),
        new stars_type("Cor Caroli", 194.05953519532213f/15, 38.194134797380414f, 2.84f),
        new stars_type("Chara", 188.48837167458393f/15, 41.234032402864734f, 4.34f),
        new stars_type("5 Canum Venaticorum", 186.13792064883444f/15, 51.45916790110722f, 4.91f),
        new stars_type("Gaia DR2 1537396673318780544", 180.52341182143272f/15, 42.9101272616439f, 5.13f),
        new stars_type("6 Canum Venaticorum", 186.55297103452128f/15, 38.90377620499422f, 5.16f),
        new stars_type("Gaia DR2 1576850723937017216", 195.36648769228512f/15, 56.31259986889402f, 4.81f),
        new stars_type("14 Canum Venaticorum", 196.52948388739242f/15, 35.68713706303738f, 5.16f),
        new stars_type("Gamma Comae Berenices", 186.8025834389235f/15, 28.143479372369974f, 4.5f),
        new stars_type("Beta Comae Berenices", 197.91223275264142f/15, 27.757304152190667f, 4.34f),
        new stars_type("Alpha Comae Berenices", 197.57751824528447f/15, 17.420492444234746f, 4.41f),
        new stars_type("35 Comae Berenices A", 193.297173431398f/15, 21.114050982284702f, 4.72f),
        new stars_type("40 Comae Berenices", 196.61522323425646f/15, 22.482824151443335f, 5.38f),
        new stars_type("41 Comae Berenices", 196.82212533571112f/15, 27.487894825892553f, 4.91f),
        new stars_type("31 Comae Berenices", 192.80016918511433f/15, 27.474733908932347f, 5.03f),
        new stars_type("26 Comae Berenices", 189.79077694321995f/15, 20.94054393683314f, 5.63f),
        new stars_type("27 Comae Berenices", 181.06990432565698f/15, 21.323465009457834f, 5.25f),
        new stars_type("36 Comae Berenices", 194.79172994460157f/15, 17.28379862224206f, 4.84f),
        new stars_type("21 Comae Berenices", 187.8254053301127f/15, 24.455411786469195f, 5.47f),
        new stars_type("17 Comae Berenices", 187.13391518553775f/15, 25.804553942128276f, 5.22f),
        new stars_type("16 Comae Berenices", 186.83933336304753f/15, 26.747895145743048f, 4.97f),
        new stars_type("13 Comae Berenices", 186.0819390410388f/15, 25.96861680811667f, 5.16f),
        new stars_type("14 Comae Berenices", 186.63256852842136f/15, 27.138861247027425f, 4.97f),
        new stars_type("12 Comae Berenices", 185.60996116059889f/15, 25.745200369091627f, 4.88f),
        new stars_type("7 Comae Berenices", 184.09950417304162f/15, 23.81533706894158f, 5.09f),
        new stars_type("HD 107325", 185.02204615038838f/15, 26.499294636570962f, 5.69f),
        new stars_type("24 Comae Berenices A", 188.86064626863603f/15, 18.263785191900784f, 5.19f),
        new stars_type("27 Comae Berenices", 191.63322010527287f/15, 16.459738445408387f, 5.25f),
        new stars_type("23 Comae Berenices", 188.74260594519149f/15, 22.498627124927108f, 4.78f),
        new stars_type("11 Comae Berenices", 185.15117118214545f/15, 17.663916718211425f, 4.88f),
        new stars_type("6 Comae Berenices", 184.04073575231973f/15, 14.766202580940668f,  5.09f),
        new stars_type("Rho Virginis", 190.5461062444869f/15, 10.12020271836352f, 4.88f),
        new stars_type("HIP 62325", 191.6282945966181f/15, 9.405438103432873f, 5.81f),
        new stars_type("2 Comae Berenices A", 181.06990432565698f/15, 21.323465009457834f,  5.94f),
        new stars_type("6 Comae Berenices", 184.04073575231973f/15, 14.766202580940668f, 5.09f),
        new stars_type("93 Leonis", 177.0785280816878f/15, 20.105804018013632f,  4.63f),
        new stars_type("Omicron Virginis", 181.31417850232535f/15, 8.595079673513192f, 4.25f),
        new stars_type("Pi Virginis", 180.24077061749765f/15, 6.483813615698796f, 4.69f),
        new stars_type("Zaniah", 184.96356208780543f/15, -0.787101009656044f, 4.89f),
        new stars_type("Xi Virginis", 176.37262386833066f/15, 8.135772252266058f, 4.88f),
        new stars_type("Theta Virginis", 197.52452726110388f/15, -5.667111449071143f, 4.34f),
        new stars_type("110 Virginis", 225.75604717118972f/15, 1.9560339720061724f, 4.53f),
        new stars_type("Gaia DR2 4421455530273467392", 229.82833990256717f/15, 1.628417336393735f, 4.84f),
        new stars_type("Gaia DR2 4419512109110088448", 225.48192772114143f/15, -0.2743114598434193f, 4.97f),
        new stars_type("16 Librae", 224.30684067079312f/15, -4.48501414879857f, 4.53f),
        new stars_type("Delta Librae", 225.2677676740552f/15, -8.653206658326877f, 4.91f),
        new stars_type("Mu Librae", 224.14196503719378f/15, -1.0657858597511476f, 5.31f),
        new stars_type("Zubeneschamali", 229.26489229012947f/15, -9.504738507576025f, 2.56f),
        new stars_type("Zubenelgenubi", 222.60447175047614f/15, -15.964206297580835f, 2.78f),
        new stars_type("Gaia DR2 4402474042571751424", 237.52959796786075f/15, -3.471811138187932f, 3.33f),
        new stars_type("Epsilon Serpentis", 237.58526565585126f, 4.412828287197681f/15, 3.75f),
        new stars_type("Unukalhai", 236.1009923990885f/15, 6.291758596974268f, 2.8f),
        new stars_type("Delta Serpentis", 233.72660188203338f/15, 10.416008853237384f, 3.86f),
        new stars_type("Beta Serpentis", 236.60150591250493f/15, 15.422129220997752f, 3.67f),
        new stars_type("Kappa Serpentis", 237.13392247893756f/15, 18.01565661905198f, 4.19f),
        new stars_type("Gamma Serpentis", 239.22815740405252f/15, 15.574585375438382f, 3.94f),
        new stars_type("Iota Cygni", 292.35067006647193f/15, 51.60043389005253f, 3.81f),
        new stars_type("Kappa Cygni", 289.3901920257318f/15, 53.253175870699934f, 3.94f),
        new stars_type("Xi Ursae Majoris A", 169.5717466200357f/15, 31.392671415465042f, 4.0f),
        new stars_type("Alula Borealis", 169.6307223267972f/15, 32.97287351950326f, 3.63f),
        new stars_type("Mu Cephei", 335.76463518817576f/15, 57.56997759552154f, 3.91f),
        new stars_type("Gaia DR2 2198483880674251136", 333.78470931347795f/15, 56.90708437294601f, 4.06f),
        new stars_type("Xi Cephei A", 330.784151195048f/15, 64.55219136041269f, 4.25f),
        new stars_type("19 Cephei", 331.0166407050703f/15, 62.2371412834382f, 5.09f),
        new stars_type("Pi Cephei A", 346.5122330498079f/15, 75.31349009415474f, 4.19f),
        new stars_type("Gaia DR2 2272649822619848064", 325.5189844120959f/15, 71.17805187402f, 4.19f),
        new stars_type("24 Cephei", 332.413962064155f/15, 72.20850594110868f, 4.94f),
        new stars_type("HIP 111532", 339.1862894469885f/15, 73.52253087710399f, 5.16f),
        new stars_type("Delta Cephei", 337.18824565590853f/15, 58.33090882205042f, 4.25f),
        new stars_type("Beta Lacertae", 336.07220874305136f/15, 52.238542035210166f, 4.56f),
        new stars_type("Alpha Lacertae", 337.92027276149435f/15, 50.24553557590577f, 3.78f),
        new stars_type("4 Lacertae", 336.22980631218576f/15, 49.35409682357942f, 4.59f),
        new stars_type("Gaia DR2 2213911506281421824", 349.6688661019607f/15, 67.97358537842f, 4.53f),
        new stars_type("Pi Cephei A", 346.5122330498079f/15, 75.31349009415474f, 4.19f),
        new stars_type("Gaia DR2 2272649822619848064", 325.5189844120959f/15, 71.17805187402f, 4.19f),
        new stars_type("Rho Cassiopeiae", 358.4043224191837f/15, 57.58911688805692f, 4.66f),
        new stars_type("HD 224572B", 359.7494139609631f/15, 55.617758595464856f, 4.84f),
        new stars_type("Zeta Cassiopeiae", 9.23745078540859f/15, 53.75922892074663f, 3.61f),
        new stars_type("Achird", 12.427992362410095f/15, 57.701405955022004f, 3.58f),
        new stars_type("Upsilon¹ Cassiopeiae", 13.914331169398308f/15, 58.86400709801422f, 4.97f),
        new stars_type("Upsilon² Cassiopeiae", 14.166937569846805f/15, 59.04230929094836f, 4.78f),
        new stars_type("Kappa Cassiopeiae", 8.165903069628907f/15, 62.80666564426004f, 4.19f),
        new stars_type("Psi Cassiopeiae", 21.840928830144993f/15, 68.15160530511771f, 4.88f),
        new stars_type("Iota Cassiopeiae", 37.192899592695696f/15, 67.26823304285921f, 4.5f),
        new stars_type("48 Cassiopeiae", 30.536281531396682f/15, 71.0100227407105f, 4.53f),
        new stars_type("50 Cassiopeiae", 30.788102880909324f/15, 72.29023797577766f, 3.95f),
        new stars_type("Phi Andromedae", 17.37701263256604f/15, 47.10812236927096f, 4.22f),
        new stars_type("Upsilon Persei", 24.320006241842652f/15, 48.56116311645643f, 3.75f),
        new stars_type("Phi Persei", 25.944417798013657f/15, 50.551235718333245f, 3.97f),
        new stars_type("Upsilon Andromedae", 24.178243842039045f/15, 41.266541297617934f, 4.19f),
        new stars_type("Tau Andromedae", 25.083163876573416f/15, 40.4540492887686f, 4.94f),
        new stars_type("HD 10307", 25.499316174540613f/15, 42.485957495049206f, 5.06f),
        new stars_type("Chi Andromedae", 24.968182855354115f/15, 44.29333552929213f, 5.16f),
        new stars_type("Almach", 31.00688643123475f/15, 42.19671365077073f, 2.23f),
        new stars_type("Gaia DR2 358813838633178368", 33.32082326611764f/15, 50.93931864785154f, 5.00f),
        new stars_type("64 Andromedae", 36.02088187360941f/15, 49.87959672933405f, 5.34f),
        new stars_type("65 Andromedae", 36.49096523696185f/15, 50.152537739781806f, 4.84f),
        new stars_type("Theta Persei", 41.01750553736152f/15, 49.0910863341041f, 4.19f),
        new stars_type("Lambda Virginis", 214.727613575073f/15, -13.497569902037863f, 4.53f),
        new stars_type("Gaia DR2 3613137118887389440", 206.53010543503646f/15, -12.551711374997389f, 5.25f),
        new stars_type("69 Virginis", 201.84448336468694f/15, -16.106547241103694f, 4.91f),
        new stars_type("89 Virginis", 207.4766948027865f/15, -18.268672033377374f, 5.13f),
        new stars_type("Psi Virginis", 193.63291168191572f/15, -9.669299480888933f, 4.81f),
        new stars_type("HD 110317J", 190.33474460440505f/15, -13.140436553099963f, 5.19f),
        new stars_type("Chi Virginis", 189.8130004592192f/15, -8.134371304956199f, 4.81f),
        new stars_type("Eta Corvi", 188.02204585467828f/15, -16.32400691804591f, 4.38f),
        new stars_type("Algorab", 187.52465300333716f/15, -16.640080989334525f, 2.94f),
        new stars_type("Gienah", 183.95729300625362f/15, -17.678556266671322f, 2.55f),
        new stars_type("Kraz", 188.6164318138586f/15, -23.53188445363164f, 2.8f),
        new stars_type("Epsilon Corvi", 182.48213624637503f/15, -22.747060325610537f, 3.17f),
        new stars_type("Alchiba", 182.1287680913028f/15, -24.864514346494857f, 4.09f),
        new stars_type("17 Crateris B", 173.04795290634428f/15, -29.400582182459246f, 5.03f),
        new stars_type("Iota Antilae", 164.19196803305988f/15, -37.276022955535986f, 4.75f),
        new stars_type("I Velorum", 141.74659886254574f/15, -53.46878347077971f, 4.41f),
        new stars_type("46 Centauri", 166.92917740576698f/15, -42.750486852225016f, 5.16f),
        new stars_type("Alpha Antilae", 156.65816771582803f/15, -30.992366037890392f, 4.41f),
        new stars_type("Q Velorum", 152.29031573098803f/15, -51.94436854562363f, 3.86f),
        new stars_type("Psi Velorum", 137.27262479540408f/15, -47.45514946229379f, 3.66f),
        new stars_type("Suhail", 137.04718671606255f/15, -43.566598930667766f, 2.33f),
        new stars_type("Naos", 120.94537652270337f/15, -40.00182777158408f, 2.13f),
        new stars_type("Tureis", 121.93559216922691f/15, -24.431835870001166f, 2.91f),
        new stars_type("Xi Puppis ", 117.28360829552184f/15, -24.86363283833447f, 3.5f),
        new stars_type("Pi Puppis ", 109.29810785215851f/15, -37.234921903975206f, 2.83f),
        new stars_type("Beta Pyxidis", 130.02341623831143f/15, -35.445623957109035f, 4.13f),
        new stars_type("Alpha Pyxidis ", 130.9934619270074f/15, -33.29830053391228f, 3.61f),
        new stars_type("Gamma Pyxidis ", 132.6804301631901f/15, -27.84009001758366f, 4.16f),
        new stars_type("30 Monocerotis", 126.38076621896748f/15, -4.039446997497781f, 3.89f),
        new stars_type("HIP 37229", 114.75805970903659f/15, -26.934313127829117f, 3.73f),
        new stars_type("11 Puppis", 119.20617217462939f/15, -23.017838555095523f, 4.31f),
        new stars_type("Theta Leporis", 91.54817690945629f/15, -15.071839591019335f, 4.69f),
        new stars_type("HD 6053", 15.44582162933051f/15, -6.110207202321501f, 4.53f),
        new stars_type("Xi1 Canis Majoris", 98.07135483697712f/15, -23.504413018213995f, 4.25f),
        new stars_type("Alula Borealis", 169.6307223267972f/15, 32.97287351950326f, 3.63f),
        new stars_type("Xi Ursae Majoris A", 169.5717466200357f/15, 31.392671415465042f, 4.00f),
        new stars_type("Iota Leonis A", 170.98159553715732f/15, 10.392734811817247f, 4.03f),
        new stars_type("Sigma Leonis", 170.16867090242258f/15, 6.001540515254776f, 4.03f),
        new stars_type("Zavijava", 177.72511830754513f/15, 1.6436666349255404f, 3.7f),
        new stars_type("Gaia DR2 3818309970064649984", 166.13842721944482f/15, 7.3549871817864245f, 4.44f),
        new stars_type("Rho Leonis", 158.247630790124f/15, 9.177444946564844f, 3.78f),
        new stars_type("31 Leonis", 152.03471947176521f/15, 9.881123019499434f, 4.5f),
        new stars_type("Subra", 145.33481763205057f/15, 9.76349564279536f, 3.63f),
        new stars_type("Iota Hydrae", 144.9721853213927f/15, -1.2723497302479245f, 4.03f),
        new stars_type("Alpha Sextanis", 152.0083287812265f/15, -0.5061866059470058f, 4.47f),
        new stars_type("Beta Sextanis", 157.5196359009227f/15, -0.7641616873499714f, 5.03f),
        new stars_type("Upsilon Leonis", 174.27825421605814f/15, -0.8849466650742454f, 4.44f),
        new stars_type("46 Leonis Minoris", 163.2298898613665f/15, 34.10693575342219f, 3.94f),
        new stars_type("Beta Leonis Minoris", 156.98173748689152f/15, 36.597353526511306f, 4.34f),
        new stars_type("21 Leonis Minoris", 151.8772845994071f/15, 35.10744431223324f, 4.53f),
        new stars_type("10 Leonis Minoris", 143.58234410922452f/15, 36.26878038227828f, 4.69f),
        new stars_type("Alterf", 142.9243266609285f/15, 22.83919821021203f, 4.41f),
        new stars_type("Kappa Leonis", 141.13578639420518f/15, 26.066642197702876f, 4.59f),
        new stars_type("Sigma2 Ursae Majoris A", 137.76079110222122f/15, 67.0107325850214f, 4.63f),
        new stars_type("5 Ursae Minoris", 217.21551107152763f/15, 75.58789142014206f, 4.38f),
        new stars_type("4 ursae Minoris", 212.2684729898268f/15, 77.41462100244343f, 4.94f),
        new stars_type("Psi1 Draconis A", 265.49604462249545f/15, 72.01151138585774f, 4.66f),
        new stars_type("Kappa Cephei", 301.83587748085665f/15, 77.60061933647974f, 4.34f),
        new stars_type("HIP 14632", 47.29964205063072f/15, 49.481484219441505f, 4.16f),
        new stars_type("Tau Persei", 43.7142820057821f/15, 52.659824581612185f, 4.06f),
        new stars_type("CE Camelopardelis", 52.55919168711405f/15, 58.74833823291177f, 4.66f),
        new stars_type("CS Camelopardelis", 52.367637734420015f/15, 59.81327716952878f, 4.28f),
        new stars_type("Alpha Camelopardalis", 73.45490473606613f/15, 66.2061547490405f, 4.28f),
        new stars_type("Gamma Camelopardalis", 57.429878118409555f/15, 71.20471623525532f, 4.63f),
        new stars_type("HIP 25110", 80.86929742702331f/15, 79.10205441722272f, 5.19f),
        new stars_type("Gaia DR2 474610073947130368", 59.28292600686068f/15, 60.97594418563515f, 4.38f),
        new stars_type("Beta Camelopardalis", 75.93286261362977f/15, 60.315159000889444f, 4.16f),
        new stars_type("12 Lyncis", 101.78661739176145f/15, 59.37609870532691f, 4.88f),
        new stars_type("Delta Aurigae", 89.96247376382581f/15, 54.16509395836793f, 3.88f),
        new stars_type("Lambda Persei", 61.74982957684217f/15, 50.23213072815085f, 4.25f),
        new stars_type("48 Persei", 62.17980060611343f/15, 47.57531386706131f, 3.98f),
        new stars_type("Mu Persei", 60.730462779920586f/15, 52.072053981493866f, 4.28f),
        new stars_type("53 Persei", 65.25956986224196f/15, 46.39366499905468f, 4.78f),
        new stars_type("Nu Persei", 64.80542084976084f/15, 50.009974685459355f, 3.86f),
        new stars_type("Sigma Persei", 52.710432799882405f/15, 47.86594305132288f, 4.47f),
        new stars_type("Psi Persei", 54.142345794021566f/15, 48.05462116827917f, 4.28f),
        new stars_type("Omega Persei", 47.87047851611753f/15, 39.48248752198399f, 4.78f),
        new stars_type("Epsilon Aurigae", 75.34269359963989f/15, 43.899977211460346f, 3.14f),
        new stars_type("58 Persei", 69.14595940169471f/15, 41.13182037000528f, 4.38f),
        new stars_type("Eta Aurigae", 76.45213983547562f/15, 41.199759531750324f, 3.11f),
        new stars_type("Nu Aurigae", 77.34532192064164f/15, 28.635697762804167f, 4.13f),
        new stars_type("Tau Aurigae", 87.36228495345928f/15, 39.063528927369674f, 4.66f),
        new stars_type("Upsilon Aurigae", 87.82929693617626f/15, 37.18219934001741f, 4.78f),
        new stars_type("Kappa1 Tauri", 66.27316299569914f/15, 22.17758422759513f, 4.25f),
        new stars_type("37 Tauri", 61.19578977679621f/15, 21.944315103009096f, 4.5f),
        new stars_type("Upsilon Tauri", 66.65227444370338f/15, 22.695271175489445f, 4.34f),
        new stars_type("Epsilon Arietis", 44.81398559884607f/15, 21.20411980516409f, 4.63f),
        new stars_type("Botein", 47.91360457546705f/15, 19.588422009149447f, 4.5f),
        new stars_type("Zeta Arietis", 48.75148254116272f/15, 20.91549108773031f, 4.88f),
        new stars_type("Pi Aurigae", 90.1007776155927f/15, 45.829455715605995f, 4.28f),
        new stars_type("Kappa Aurigae", 93.80993230251457f/15, 29.363546777266027f, 4.47f),
        new stars_type("136 Tauri", 88.28795674567353f/15, 27.51153910739953f, 4.53f),
        new stars_type("139 Tauri", 89.51589826909813f/15, 25.817699857247394f, 4.78f),
        new stars_type("Tegmine", 123.05902301708488f/15, 17.509584757620708f, 4.75f),
        new stars_type("Procyon", 114.86329344339771f/15, 5.087903485634042f, 0.46f),
        new stars_type("Gomeisa", 111.79587923164567f/15, 8.154864757381395f, 2.84f),
        new stars_type("Eta Leporis", 89.06711297940839f/15, -14.299827103533444f, 3.78f),
        new stars_type("Zeta Leporis", 86.6701080821546f/15, -14.927492933200988f, 3.56f),
        new stars_type("Arneb", 83.18498879575593f/15, -17.959086662964687f, 2.64f),
        new stars_type("Delta Leporis", 87.81993413432424f/15, -21.01279414499501f, 3.92f),
        new stars_type("Gamma Leporis", 86.14743494794307f/15, -22.584131198622433f, 3.69f),
        new stars_type("Nihal", 82.13026984976166f/15, -20.870219094011432f, 2.95f),
        new stars_type("Lambda Leporis", 79.87113437929504f/15, -13.30739105766086f, 4.19f),
        new stars_type("Kappa Leporis", 78.25710828272119f/15, -13.068437198734406f, 4.31f),
        new stars_type("Iota Leporis", 78.1043675599705f/15, -11.999961691344728f, 4.41f),
        new stars_type("Eta Orionis", 81.1476455053656f/15, -2.5319268925195986f, 3.28f),
        new stars_type("Rho Orionis", 78.34804434583562f/15, 2.7267056492589474f, 4.63f),

        new stars_type("Sigma bootis", 218.67103773973483f/15, 29.745711934026136f, 4.53f),
        new stars_type("HD 46487", 98.4074679693527f/15, -1.2123867156109815f, 5.03f),
        new stars_type("HD 45416", 96.80498973880131f/15, 0.3081442150651191f, 5.34f),
        new stars_type("HD 44131", 95.00828028778403f/15, -2.9514822681151673f, 5.00f),
        new stars_type("NGC 2232 1", 96.9912997723673f/15, -4.7743475712447685f, 4.93f),
        new stars_type("Gaia DR2 3300128870247575424", 63.47288280112758f/15, 9.260221998929708f, 4.63f),
        new stars_type("88 Tauri", 68.92715017954758f/15, 10.157728850701217f, 4.28f),
        new stars_type("Mu Tauri", 56.010589151111304f/15, 25.057906515174263f, 4.25f),
        new stars_type("Nu Tauri", 56.198955460666376f/15, 24.20706795864948f, 3.91f),
        new stars_type("90 Tauri", 69.53746569730659f/15, 12.50158079919529f, 4.31f),
        new stars_type("Omicron Orionis", 73.12899878377071f/15, 14.241385567101263f, 4.69f),
        new stars_type("Omicron2 Orionis", 74.08377130019713f/15, 13.504402919833217f, 4.22f),
        new stars_type("11 Orionis", 76.14361702006362f/15, 15.396197032805542f, 4.63f),
        new stars_type("15 Orionis", 77.42394864476795f/15, 15.585394960440057f, 4.88f),
        new stars_type("HD 33554", 77.93498169822256f/15, 16.039004040257215f, 5.28f),
        new stars_type("119 Tauri", 83.06672966101581f/15, 18.59150839793525f, 4.31f),
        new stars_type("HD 36408B", 83.05798776137875f/15, 17.04614145093495f, 5.5f),
        new stars_type("134 Tauri", 87.38660518295467f/15, 12.639482953392918f, 4.84f),
        new stars_type("Gaia DR2 3335865334613307136", 87.51030261093545f/15, 9.864678588250444f, 5.63f),
        new stars_type("Phi1 Orionis", 83.70504581048641f/15, 9.4972222986118f, 4.34f),
        new stars_type("Phi2 Orionis", 84.22943349366899f/15, 9.282412822187151f, 4.22f),
        new stars_type("52 Orionis B", 87.0094641750524f/15, 6.445952765747198f, 5.31f),
        new stars_type("Omega Orionis", 84.78859096536475f/15, 4.1107369827120435f, 4.47f),
        new stars_type("32 Orionis", 82.70628888311875f/15, 5.939726338978538f, 4.16f),
        new stars_type("51 Orionis", 85.61809277775191f/15, 1.461324922476912f, 5.03f),
        new stars_type("HD 37756", 85.21130809171673f/15, -1.128791214877708f, 4.84f),
        new stars_type("Sigma Orionis", 84.69532794401862f/15, -2.6067685294877068f, 3.67f),
        new stars_type("VV Orionis", 83.38290926142909f/15, -1.1695207170922812f, 5.28f),
        new stars_type("HD 36591", 83.17230440543284f/15, -1.591839295405641f, 5.25f),
        new stars_type("NGC 1980", 83.86008710028939f/15, -5.924090244551637f, 2.5f),
        new stars_type("Theta1 Orionis C", 83.82530353402949f/15, -5.400310943164196f, 4.59f),
        new stars_type("42 Orinois", 83.84922825905977f/15, -4.837942870124082f, 4.5f),
        new stars_type("Upsilon Orionis", 82.97357420877246f/15, -7.300404892899049f, 4.5f),
        new stars_type("49 Orionis", 84.72111093495268f/15, -7.213048891307543f, 4.81f),
        new stars_type("Tau Aurigae", 87.29112846026162f/15, 39.16852623897074f, 4.66f),
        new stars_type("Phi Aurigae", 81.9016999877421f/15, 34.46585599910433f, 5.22f),
        new stars_type("19 Aurigae", 80.01557981044779f/15, 33.96039268155662f, 5.09f),
        new stars_type("IQ Aurigae", 79.74689895937261f/15, 33.74145923974697f, 5.31f),
        new stars_type("HIP 24737", 79.5648930885844f/15, -74.71033696273524f, 4.69f),
        new stars_type("14 Aurigae", 78.86422259627345f/15, 32.68234460353805f, 5.06f),
        new stars_type("36 Geminorum", 102.89323403129771f/15, 21.751652317191294f, 5.25f),
        new stars_type("57 Geminorum", 110.8674397297495f/15, 25.03878735111722f, 5.16f),
        new stars_type("Omega Geminorum", 105.59846564380217f/15, 24.20363509615301f, 5.34f),
        new stars_type("Nu Persei", 64.93087176720178f/15, 50.11229349638411f, 3.85f),
        new stars_type("40 Persei", 55.603069173194946f/15, 33.96223183708796f, 4.94f),
        new stars_type("42 Persei", 57.39258455128622f/15, 33.0838765064923f, 5.16f),
        new stars_type("HD 20468", 49.68262455972324f/15, 34.222617549318464f, 4.97f),
        new stars_type("24 Persei", 44.761658521485906f/15, 35.174847353814734f, 5.09f),
        new stars_type("17 Persei", 42.8870049170804f/15, 35.048720495730045f, 4.66f),
        new stars_type("21 Persei", 44.31523717091123f/15, 31.92774942725678f, 5.09f),
        new stars_type("HD 20644", 50.08480629155294f/15, 29.048386408151032f, 4.59f),
        new stars_type("39 Arietis", 41.96973955863257f/15, 29.24458455084607f, 4.66f),
        new stars_type("HD 215446", 341.30970573179536f/15, 0.3720394900903893f, 4.91f),
        new stars_type("HD 217382", 343.5309017111799f/15, 84.34549248425822f, 4.81f),
        new stars_type("HD 5848", 17.36638136504559f/15, 86.26315903532777f, 4.38f),
        new stars_type("15 Draconis", 247.00995515705117f/15, 68.76802059189932f, 4.94f),
        new stars_type("HD 148293", 245.45273423545564f/15, 69.10934522768763f, 5.41f),
        new stars_type("HD 145454", 241.56566606827832f/15, 67.80295250117422f, 5.44f),
        new stars_type("HIP 82860", 253.9830653903447f/15, 65.14008553634785f, 4.97f),
        new stars_type("18 Draconis", 250.25135031543257f/15, 64.58118879931058f, 5.00f),
        new stars_type("RR Ursae Minoris", 224.3950073429196f/15, 65.9325976765071f, 4.56f),
        new stars_type("HIP 74605", 228.6623049416036f/15, 67.34497640770853f, 5.25f),
        new stars_type("HD 141653", 236.66707720541896f/15, 62.59930592517897f, 5.22f),
        new stars_type("HD 81817", 144.35146736224468f/15, 81.32425042562622f, 4.41f),
        new stars_type("HD 49878", 105.06520140761485f/15, 76.97298314523758f, 4.69f),
        new stars_type("HD 42818", 94.70113077103213f/15, 69.31061315292163f, 4.75f),
        new stars_type("Xi Aurigae", 88.70752130753853f/15, 55.69765977996858f, 4.97f),
        new stars_type("Beta Camelopardalis", 75.86618520045127f/15, 60.43091780900105f, 4.16f),
        new stars_type("HIP 78180", 239.4245224067122f/15, 54.74997899617758f, 5.00f),
        new stars_type("HIP 72644", 222.78583404073842f/15, 0.5567361780190847f, 5.63f),
        new stars_type("10 Draconis", 207.85808233061798f/15, 64.72327753159793f, 4.59f),
        new stars_type("8 Draconis", 193.8846389485774f/15, 65.44291527266755f, 5.28f),
        new stars_type("9 Draconis", 194.9512389633777f/15, 66.59093828873026f, 5.5f),
        new stars_type("7 Draconis", 191.8661708873783f/15, 66.78382643406813f, 5.53f),
        new stars_type("42 herculis", 249.68822540643473f/15, 48.914758118230274f, 4.94f),
        new stars_type("52 Herculis", 252.31163661249624f/15, 45.97373437218502f, 4.81f),
        new stars_type("HD 155410", 257.3882743789108f/15, 40.77706357970886f, 5.22f),
        new stars_type("Theta Coronae Borealis", 233.23074030965608f/15, 31.348358389361096f, 4.09f),
        new stars_type("Nusakan", 231.9562807016411f/15, 29.106103677611483f, 3.73f),
        new stars_type("Alphecca", 233.67254376294218f/15, 26.714295174747274f, 2.22f),
        new stars_type("Gamma Coronae Borealis", 235.6828850956564f/15, 26.28540304311455f, 3.81f),
        new stars_type("Delta Coronae Borealis", 237.3997263852064f/15, 26.060409079253322f, 4.72f),
        new stars_type("Epsilon Coronae Borealis", 239.39663593730245f/15, 26.878160078161077f, 4.28f),
        new stars_type("Iota Coronae Borealis", 240.34800862015004f/15, 29.845842550193915f, 4.94f),
        new stars_type("Eta Coronae Borealis", 230.80213222234477f/15, 30.287113837658584f, 5.09f),
        new stars_type("Tau Bootis A", 206.8133909945028f/15, 17.457173637726076f, 4.28f),
        new stars_type("12 Bootis", 212.58885203263262f/15, 25.09856337519518f, 4.91f),
        new stars_type("9 Bootis", 209.14256200431043f/15, 27.491866867445157f, 5.16f),
        new stars_type("6 Bootis", 207.42905226972943f/15, 21.260954507976784f, 5.03f),
        new stars_type("Gaia DR2 3726490479878642688", 204.8947064909037f/15, 10.746433013348987f, 5.47f),
        new stars_type("Sigma Virginis", 199.40115348731604f/15, 5.469941628676424f, 4.84f),
        new stars_type("78 Virginis", 203.52839900723217f/15, 3.6524377824864804f, 4.91f),
        new stars_type("84 Virginis B", 205.7638400653598f/15, 3.530777628469371f, 5.5f),
        new stars_type("TYC 905-1418-2", 213.7117811769364f/15, 10.099877227469719f, 5.44f),
        new stars_type("HD 126129", 215.8437803091314f/15, 8.444908377099631f, 4.88f),
        new stars_type("HIP 70027", 214.93366468026375f/15, 16.298432736589948f, 5.00f),
        new stars_type("18 Bootis", 214.81354106270547f/15, 12.995045495231665f, 5.47f),
        new stars_type("Phi Virginis", 217.06027874633156f/15, -2.2295803585113094f, 4.94f),
        new stars_type("Upsilon Virginis", 214.8848037763895f/15, -2.2658341187143045f, 5.28f),
        new stars_type("90 Virginis", 208.67627429545263f/15, -1.500258135639256f, 5.31f),
        new stars_type("82 Virginis", 205.39739993488425f/15, -8.711664810734892f, 5.09f),
        new stars_type("76 Virginis", 203.24182490427663f/15, -10.165171297158025f, 5.34f),
        new stars_type("74 Virginis", 202.99494899247074f/15, -6.265687875744052f, 4.75f),
        new stars_type("Chi1 Hydrae", 166.33229144785633f/15, -27.305716865459043f, 5.00f),
        new stars_type("HD 96819", 167.19472193806507f/15, -28.07711236880513f, 5.44f),
        new stars_type("Phi Hydrae", 159.65727798195095f/15, -17.0044161831815f, 5.06f),
        new stars_type("Felis", 148.67846747783722f/15, -19.13909789122005f, 5.03f),
        new stars_type("I Hydrae", 145.27754227040873f/15, -23.72154247967597f, 4.72f),
        new stars_type("HD 84117", 145.6045422022708f/15, -24.04501742550668f, 5.03f),
        new stars_type("HD 85859", 148.60324588343744f/15, -26.058652114844005f, 5.03f),
        new stars_type("Theta Antilae", 146.01047434238163f/15, -27.894529551664554f, 4.88f),
        new stars_type("Kappa Hydrae", 145.128703509069f/15, -14.460852401560532f, 5.00f),
        new stars_type("26 Hydrae", 139.96497473755664f/15, -12.10887288183793f, 4.91f),
        new stars_type("27 Hydrae", 140.20084452223517f/15, -9.665485172261482f, 4.97f),
        new stars_type("23 Hydrae", 139.1716430647394f/15, -6.483558016521149f, 5.38f),
        new stars_type("15 Hydrae A", 132.94240057502893f/15, -7.3063514585475f, 5.5f),
        new stars_type("12 Hydrae", 131.62399654253412f/15, -13.682320871517735f, 4.44f),
        new stars_type("F Hydrae", 130.9787654734791f/15, -7.358838293678921f, 4.75f),
        new stars_type("30 Monocerotis", 126.38076621896748f/15, -4.039446997497781f, 3.89f),
        new stars_type("25 Monocerotis", 114.42322139722245f/15, -4.020069135337112f, 5.22f),
        new stars_type("HD 62902", 116.51718292351057f/15, -6.911293811802471f, 5.63f),
        new stars_type("27 Monocerotis", 119.97143868215768f/15, -3.808590689102027f, 5.09f),
        new stars_type("19 Monocerotis", 105.78945191247496f/15, -4.328307486756205f, 4.91f),
        new stars_type("20 Monocerotis", 107.44577352845134f/15, -4.294020091350161f, 5.06f),
        new stars_type("HD 44131", 94.98717793377855f/15, -3.0800542296203703f, 5.00f),
        new stars_type("NGC 2232 1", 96.98414947868733f/15, -4.896802122591404f, 4.97f),
        new stars_type("HD 46487", 98.29946331403788f/15, -1.3066161230717617f, 5.03f),
        new stars_type("HD 45416", 96.70803014976515f/15, 0.1632992054135295f, 5.34f),
        new stars_type("HD 43318", 93.90548154654181f/15, -0.6466627093899624f, 5.72f),
        new stars_type("HD 50747", 103.61023230050887f/15, -1.1349908106715412f, 5.47f),
        new stars_type("13 Monocerotis", 98.23341532361005f/15, 7.323818584635733f, 4.50f),
        new stars_type("17 Monocerotis", 101.831098543568f/15, 8.030410201076219f, 4.91f),
        new stars_type("NGC 2264 131", 100.24672417757748f/15, 9.885498483918402f, 4.53f),
        new stars_type("Omicron Geminorum", 114.78494951643678f/15, 34.57206121431337f, 4.97f),
        new stars_type("Pi Geminorum", 116.87625619458441f/15, 33.4155709365502f, 5.22f),
        new stars_type("DU Lyncis", 116.65747091845122f/15, 37.50685130620031f, 5.22f),
        new stars_type("65 Aurigae", 110.50749967978298f/15, 36.747015882874045f, 5.28f),
        new stars_type("63 Aurigae", 107.92178307551652f/15, 39.314003397931415f, 5.03f),
        new stars_type("66 Aurigae", 111.03870664848301f/15, 40.66414341109074f, 5.38f),
        new stars_type("Psi7 Aurigae", 102.68812478129803f/15, 41.772587487480585f, 5.13f),
        new stars_type("Psi2 Aurigae", 99.82312033932634f/15, 42.48034846797748f, 4.94f),
        new stars_type("HIP 32480", 101.69264764273754f/15, 43.569301107779125f, 5.34f),
        new stars_type("Psi4 Aurigae", 100.77547392618585f/15, 44.51478035325215f, 5.16f),
        new stars_type("Psi10 Aurigae", 104.4044785825968f/15, 45.09407884832102f, 5.66f),
        new stars_type("HD 56169", 109.63485629226345f/15, 49.4671606747058f, 5.03f),
        new stars_type("Psi6 Aurigae", 101.91714295541307f/15, 48.77713540423607f, 5.38f),
        new stars_type("Psi Aurigae", 96.24103835027994f/15, 49.28390670812395f, 5.00f),
        new stars_type("41 Aurigae A", 92.88816771144866f/15, 48.7074142008545f, 5.81f),
        new stars_type("Delta Aurigae", 89.86523585890623f/15, 54.27467478256285f, 3.88f),
        new stars_type("HD 48767", 102.05167954139093f/15, 55.70372196845802f, 5.63f),
        new stars_type("RR Lyncis", 96.62583757802443f/15, 56.29084201934997f, 5.59f),
        new stars_type("13 Lyncis", 101.7227332304346f/15, 57.16726854586894f, 5.50f),
        new stars_type("12 Lyncis", 101.57193720586473f/15, 59.445597163886845f, 4.88f),
        new stars_type("Pi2 Ursae Majoris", 130.0263748755034f/15, 64.33183850734622f, 4.72f),
        new stars_type("Rho Ursae Majoris", 135.60965692508157f/15, 67.62653412606186f, 4.78f),
        new stars_type("Pi1 Ursae Majoris", 129.7790449987869f/15, 65.0192900366314f, 5.75f),
        new stars_type("2 Ursae Majoris", 128.66656484143158f/15, 65.13319298508848f, 5.50f),
        new stars_type("Sigma1 Ursae Majoris", 137.0976608806673f/15, 66.87305327249916f, 5.25f),
        new stars_type("Sigma2 Ursae Majoris A", 137.59826115667667f/15, 67.13362657576307f, 4.63f),
        new stars_type("24 Ursae Majoris", 143.61942231458804f/15, 69.83068385576529f, 4.69f),
        new stars_type("ET Ursae Majoris", 156.03259900576703f/15, 65.56632923065649f, 4.91f),
        new stars_type("Gaia DR2 1059521225937701632", 160.48392976447823f/15, 65.71598438637281f, 4.72f),
        new stars_type("HD 92523", 160.7567815564692f/15, 69.06727052964314f, 5.13f),
        new stars_type("HD 91190", 158.7725122570992f/15, 75.7129084407845f, 5.00f),
        new stars_type("15 Ursae Majoris", 137.20479374382302f/15, 51.59842524048313f, 4.53f),
        new stars_type("18 Ursae Majoris", 139.05364871651437f/15, 54.00926367374331f, 4.84f),
        new stars_type("17 Ursae Majoris", 138.95722409192788f/15, 56.741279076326805f, 5.38f),
        new stars_type("HD 77309", 135.9972790981118f/15, 54.276940604949814f, 5.75f),
        new stars_type("CS Ursae Majoris", 146.6170847953479f/15, 57.117412519720915f, 5.13f),
        new stars_type("16 Ursae Majoris", 138.5841470897035f/15, 61.41030314428514f, 5.28f),
        new stars_type("HIP 51459", 157.65517382143014f/15, 55.980393770343866f, 4.91f),
        new stars_type("HD 86378", 149.96653842705595f/15, 56.804321181841665f, 5.63f),
        new stars_type("37 Ursae Majoris", 158.79762003113507f/15, 57.071781014058246f, 5.22f),
        new stars_type("38 Ursae Majoris", 160.48392976447823f/15, 65.71598438637281f, 5.78f),
        new stars_type("HD 102328", 176.73727985042788f/15, 55.62512552223777f, 5.41f),
        new stars_type("HIP 52469", 160.88531071466585f/15, 46.20357666384268f, 5.25f),
        new stars_type("HD 95212", 165.06132998545385f/15, 45.52628265960704f, 5.59f),
        new stars_type("15 Leonis Minoris", 147.15085557933895f/15, 46.01535441812499f, 5.19f),
        new stars_type("31 Ursae Majoris", 148.9252195111679f/15, 49.81765974029488f, 5.28f)
#endregion
    };

    /// <summary>
    /// The constant conversion rate from degrees to radians.
    /// </summary>
    private const float deg2rad = 0.0174533f;

    private static Dictionary<string, ParticleSystem> constellationParticleSystems = new Dictionary<string, ParticleSystem>();

    public static Dictionary<string, ParticleSystem> ConstellationParticleSystems
    {
        get => constellationParticleSystems;
    }

    private static List<string> constellationNames = new List<string>();

    public static List<string> ConstellationNames
    {
        get => constellationNames;
    }

    private ParticleSystem[] particleSystems;

    private int currentParticleSystem = 0;

    private Particle[] currentParticleStars;

    private int currentParticlesIndex = 0;
    #endregion

    #region Constellations
    #region Lines
    /// <summary>
    /// The prefab that will be spawned to create constellation lines.
    /// </summary>
    [SerializeField]
    [Tooltip("The constellation lines prefab")]
    private GameObject constellationLines;

    /*
    [Tooltip("The default color of constellation lines")]
    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color defaultLineColor;

    [Tooltip("How thick the lines are")]
    [SerializeField] private float lineThickness;
    */

    /// <summary>
    /// The list of active constellations that holds reference to their
    /// </summary>
    private static Dictionary<string, List<LineRenderer>> constellations = new Dictionary<string, List<LineRenderer>>();

    /// <summary>
    /// Getter for constellations and their linerenderers.
    /// </summary>
    public static Dictionary<string, List<LineRenderer>> Constellations
    {
        get => constellations;
    }

    /// <summary>
    /// Holds true if the current stars are in a constellation.
    /// </summary>
    private bool isConstellation = false;

    /// <summary>
    /// The name of the current constellation.
    /// </summary>
    private string currentConstellation = "";

    /// <summary>
    /// A list of the stars alread placed.
    /// </summary>
    private List<string> alreadyUsedNames = new List<string>();

    /// <summary>
    /// A bool reference to see if a constellation line renderer has been started.
    /// </summary>
    private bool hasStart = false;
    #endregion

    #region Connect The Dots Reference
    [Tooltip("The prefab for connect the dot minigames")]
    [SerializeField]
    private GameObject connectTheDotsSphere;

    private List<GameObject> currentConnectTheDotsGame = new List<GameObject>();

    [Tooltip("The list of constellations that will be connect the dot games")]
    [SerializeField]
    private List<string> connectTheDotsConstelllations = new List<string>();

    private bool connectTheDotsGame = false;

    private static Dictionary<string, List<GameObject>> connectTheDotGames = new Dictionary<string, List<GameObject>>();

    public static Dictionary<string, List<GameObject>> ConnectTheDotGames
    {
        get => connectTheDotGames;
    }
    #endregion
    #endregion

    AnimationCurve twinkleCurve;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes necessary values.
    /// </summary>
    void Awake()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        InitializeStars();
    }

    private void SetTwinkleCurve(float minSize, float maxSize, float minTime, float maxTime)
    {
        twinkleCurve = new AnimationCurve();

        float time = 0;

        for(int i = 0; i<1200; i++)
        {
            twinkleCurve.AddKey((float)time/(1200+time), SizeGetter(minSize, maxSize, i));
            time += Mathf.Lerp(minTime, maxTime, Random.value);
        }
    }

    private float SizeGetter(float minSize, float maxSize, int i)
    {
        if(i % 2 == 1)
        {
            return 1;
        }

        return Mathf.Lerp(minSize, 1, Random.value);
    }

    /// <summary>
    /// Initializes the stars.
    /// </summary>
    private void InitializeStars()
    {
        Invoke("CreateParticleField", 0.05f);
        Invoke("SetRotation", 0.06f);
    }

    private void InitializeNewParticleSystem()
    {
        if (currentParticleSystem < particleSystems.Length)
        {
            ps = particleSystems[currentParticleSystem];

            if (currentParticleSystem >= 20)
            {
                if (currentParticleSystem == 20)
                {
                    RandomizeStars(currentA+1);
                }

                SetTwinkleCurve(constellationData.MinStarSize, constellationData.MaxStarSize, constellationData.MinStarTime, constellationData.MaxStarTime);
            }
            else
            {
                SetTwinkleCurve(constellationData.MinConstellationStarSize, constellationData.MaxConstellationStarSize, constellationData.MinConstellationStarTime, constellationData.MaxConstellationStarTime);

            }

            var sz = ps.sizeOverLifetime;
            sz.enabled = true;
            sz.size = new MinMaxCurve(1, twinkleCurve);

            currentParticleStars = new Particle[ps.main.maxParticles];
            ps.GetParticles(currentParticleStars);
            maxParticles = ps.main.maxParticles;
            currentParticlesIndex = 0;
        }
    }

    /// <summary>
    /// sets the rotation of the sphere to the time and latitude of Peoria on April 22nd at 9 p.m.
    /// </summary>
    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(40.6936f, 0, -28.9f));
    }

    int currentA = 0;
    /// <summary>
    /// Places all of the stars and creates the constellation lines.
    /// </summary>
    private void CreateParticleField()
    {
        #region Fields
        #region Constellation Lines
        LineRenderer constellationLine = null;

        List<Vector3> starPositions = new List<Vector3>();
        #endregion
        #endregion

        // Gets the particles that will be modified into stars
        //ps.GetParticles(particleStars);
        InitializeNewParticleSystem();


        // Assigns all of the stars to their places
        for (int a = 0; a < star_Database.Length; a++)
        {
            Vector3 pos = Vector3.zero;
            CalculatePlacement(a, ref pos);

            bool nameStartEnd = star_Database[a].name == "start" || star_Database[a].name == "end";

            currentA = a;

            if (currentParticlesIndex >= 50)
            {
                SetParticleSystem();
            }

            CheckIfConstellation(a);

            SpawnStar(a, nameStartEnd, pos);

            if (isConstellation)
            {
                SetLinePoints(ref constellationLine, star_Database[a].name, ref starPositions, pos);
            }
        }

        // Sets the background stars
        SetParticleSystem();
        star_Database = new stars_type[0];
    }

    private void SetParticleSystem()
    {
        particleSystems[currentParticleSystem].SetParticles(currentParticleStars, particleSystems[currentParticleSystem].main.maxParticles);
        currentParticleSystem++;
        InitializeNewParticleSystem();
    }

    private void RandomizeStars(int a)
    {
        int startingA = a;

        for(int i = a; i < star_Database.Length; i++)
        {
            stars_type type = star_Database[a];
            int randomIndex = Random.Range(startingA, star_Database.Length - 1);
            star_Database[a] = star_Database[randomIndex];
            star_Database[randomIndex] = type;
        }
    }

    /// <summary>
    /// Calculates the x, y, and z cordinates
    /// </summary>
    /// <param name="a">The current index in the star database.</param>
    /// <param name="pos">The return position of the star.</param>
    private void CalculatePlacement(int a, ref Vector3 pos)
    {
        #region Fields
        float x = 0;
        float y = 0;
        float z = 0;
        float r = 1000.0f;
        #endregion

        // Calculates the RA and the declenation
        float ra = star_Database[a].ra * -15.0f * deg2rad;
        float dec = star_Database[a].dec * deg2rad;

        SphereicalToCartesian(ra, dec, r, ref x, ref y, ref z);
        pos = new Vector3(x, y, z);
    }

    /// <summary>
    /// Checks if the current node is a constellation start/end.
    /// </summary>
    /// <param name="a">The current index in the star database.</param>
    private void CheckIfConstellation(int a)
    {
        if (star_Database[a].name.Contains("Constellation"))
        {
            isConstellation = !isConstellation;

            if (connectTheDotsConstelllations.Contains(ParseConstellationName(a)))
            {
                if (connectTheDotsGame)
                {
                    connectTheDotGames.Add(ParseConstellationName(a), currentConnectTheDotsGame);
                }
                else
                {
                    currentConnectTheDotsGame = new List<GameObject>();
                }

                connectTheDotsGame = !connectTheDotsGame;
            }

            if (isConstellation)
            {
                constellationParticleSystems.Add(currentConstellation, particleSystems[currentParticleSystem]);
                currentConstellation = ParseConstellationName(a);

                constellations.Add(currentConstellation, new List<LineRenderer>());
                constellationNames.Add(currentConstellation);
            }

            if (!isConstellation)
            {
                SetParticleSystem();
            }
        }
    }

    /// <summary>
    /// Parses the name of the constellation from the constellation node.
    /// </summary>
    /// <param name="a">The current index in the star database.</param>
    /// <returns></returns>
    private string ParseConstellationName(int a)
    {
        string name = star_Database[a].name;
        name = name.Substring(15, name.Length-15);
        currentConstellation = name;
        return name;
    }

    /// <summary>
    /// Position the star into its correct placement.
    /// </summary>
    /// <param name="a">The current index in the star database.</param>
    /// <param name="nameStartEnd">Holdes true if the current node is a start or end node.</param>
    /// <param name="pos">The spawn position of the star.</param>
    private void SpawnStar(int a, bool nameStartEnd, Vector3 pos)
    {
        if (!alreadyUsedNames.Contains(star_Database[a].name) && !nameStartEnd && !star_Database[a].name.Contains("Constellation"))
        {
            // Sets the values of the star
            currentParticleStars[currentParticlesIndex].position = pos;
            currentParticleStars[currentParticlesIndex].remainingLifetime = Mathf.Infinity;
            currentParticleStars[currentParticlesIndex].startSize = 2.0f * (8.0f - star_Database[a].mag);
            currentParticlesIndex++;

            if (connectTheDotsGame)
            {
                GameObject node = Instantiate(connectTheDotsSphere, pos - (Camera.main.transform.position - pos).normalized * 25, Quaternion.identity, transform);
                node.name = star_Database[a].name;
                currentConnectTheDotsGame.Add(node);
            }

            alreadyUsedNames.Add(star_Database[a].name);
        }
    }

    /// <summary>
    /// Gets the spherical values needed to place the star properly.
    /// </summary>
    /// <param name="ra">The right ascension of the star.</param>
    /// <param name="dec">The declenation of the star.</param>
    /// <param name="r">The radius of the sphere.</param>
    /// <param name="x">Returns the x coordinate back.</param>
    /// <param name="y">Returns the y coordinate back.</param>
    /// <param name="z">Returns the z coordinate back.</param>
    private void SphereicalToCartesian(float ra, float dec, float r, ref float x, ref float y, ref float z)
    {
        // az and alt are in Radians
        dec = (Mathf.PI / 2) - dec;
        var rr = r * Mathf.Sin(dec);
        z = rr * Mathf.Cos(ra);
        x = rr * Mathf.Sin(ra);
        y = r * Mathf.Cos(dec);
    }

    #region Constellation Lines
    /// <summary>
    /// Creates and sets the positions of linerenderer.
    /// </summary>
    /// <param name="constellationLine">The linerender for these lines.</param>
    /// <param name="name">The name of the star.</param>
    /// <param name="starPositions">The list of star positions for this linerenderer.</param>
    /// <param name="pos">The current star position.</param>
    private void SetLinePoints(ref LineRenderer constellationLine, string name, ref List<Vector3> starPositions, Vector3 pos)
    {
        if (name.Equals("start"))
        {
            hasStart = true;
            CreateNewLineRenderer(ref constellationLine, ref starPositions);
        }
        else if (!hasStart)
        {
            return;
        }
        else if (name.Equals("end"))
        {
            for (int i = 0; i < starPositions.Count; i++)
            {
                constellationLine.SetPosition(i, starPositions[i]-(Camera.main.transform.position-starPositions[i]).normalized* 25);
            }

            constellations[currentConstellation].Add(constellationLine);
            constellationLine = null;
            hasStart = false;
        }
        else
        {
            TrackStarPositions(ref constellationLine, ref starPositions, pos);
        }
    }

    #region Helper Functions
    /// <summary>
    /// Spawns the lineRenderer gameobject and intializes values.
    /// </summary>
    /// <param name="constellationLine">The lineRenderer for the constellation.</param>
    /// <param name="starPositions"></param>
    private void CreateNewLineRenderer(ref LineRenderer constellationLine, ref List<Vector3> starPositions)
    {
        GameObject tempRef = Instantiate(constellationLines, particleSystems[currentParticleSystem].gameObject.transform);
        constellationLine = tempRef.GetComponent<LineRenderer>();
        constellationLine.positionCount = 0;
        constellationLine.material.color = constellationData.DefaultColor;
        constellationLine.startWidth = constellationData.LineWidth;
        constellationLine.endWidth = constellationData.LineWidth;
        starPositions.Clear();
    }

    /// <summary>
    /// Creates references to star's positions.
    /// </summary>
    /// <param name="constellationLine">The linerenderer of the constellation.</param>
    /// <param name="starPositions">The list of star positons in the constellation.</param>
    /// <param name="pos">The position of the current star.</param>
    private void TrackStarPositions(ref LineRenderer constellationLine, ref List<Vector3> starPositions, Vector3 pos)
    {
        constellationLine.positionCount++;
        starPositions.Add(pos);
    }
    #endregion
    #endregion
    #endregion
}

/*****************************************************************************
// File Name :         stars_type.cs
// Author :            Jacob Welch
// Creation Date :     13 November 2021
//
// Brief Description : Holds the variables of stars.
*****************************************************************************/
public class stars_type
{
    /// <summary>
    /// The name of the star.
    /// </summary>
    [HideInInspector]
    public string name;

    /// <summary>
    /// The right ascension of the star.
    /// </summary>
    [HideInInspector]
    public float ra;

    /// <summary>
    /// The declenation of the star.
    /// </summary>
    [HideInInspector]
    public float dec;

    /// <summary>
    /// The magnitude of the star.
    /// </summary>
    [HideInInspector]
    public float mag;

    /// <summary>
    /// A constructor for stars.
    /// </summary>
    /// <param name="name">The name of the star.</param>
    /// <param name="ra">The right ascension of the star.</param>
    /// <param name="dec">The declenation of the star.</param>
    /// <param name="mag">The magnitude of the star.</param>
    /// <param name="bvColor">The color of the star.</param>
    public stars_type(string name, float ra, float dec, float mag)
    {
        this.name = name;
        this.ra = ra;
        this.dec = dec;
        this.mag = mag;
    }
}
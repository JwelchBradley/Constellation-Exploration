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
    #region Fields
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
        #region Finished
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
        #endregion

        #region Need Magnitude
        

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

        /// Need Magnitues
        #region Up Arm
        // Orion Up Arm 9-16 indexes
        new stars_type("start", 0, 0, 0),
        new stars_type("Betelgeuse", 5.919500f, 7.243773685353041f, 0.500000f),
        new stars_type("Mu Orionis", 90.81583987857081f/15, 9.530229476781042f, 0.000000f),
        new stars_type("Xi Orionis", 93.24749286638966f/15, 14.100099175230447f, 0.000000f),
        new stars_type("64 Orionis", 91.04442726234083f/15, 19.830121936059367f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Xi Orionis", 6.216666f, 14.120900f, 0.000000f),
        new stars_type("Nu Orionis", 92.02701737861587f/15, 14.62005495583628f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Mu Orionis", 90.81583987857081f/15, 9.530229476781042f, 0.000000f),
        new stars_type("Nu Orionis", 92.02701737861587f/15, 14.62005495583628f, 0.000000f),
        new stars_type("Chi Orionis", 5.916600f, 20.164610f, 0.000000f),
        new stars_type("end", 0, 0, 0),
        #endregion

        // Need Magnitude
        #region Box Arm
        new stars_type("start", 0, 0, 0),
        new stars_type("Bellatrix", 5.418851f, 6.349702f, 1.640000f),
        new stars_type("PI^3 Orionis", 72.58677163058913f/15, 6.713162919257889f, 0.000000f),
        new stars_type("PI^2 Orionis", 72.80704102028638f/15, 8.770450922740736f, 0.000000f),
        new stars_type("PI^1 Orionis", 73.52495589495844f/15, 10.002482196142342f, 4.740000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("PI^3 Orionis", 72.58677163058913f/15, 6.713162919257889f, 0.000000f),
        new stars_type("PI^4 Orionis", 72.8190242880102f/15, 5.335948790127093f, 0.000000f),
        new stars_type("PI^5 Orionis", 73.48167330848129f/15, 2.6963509720090943f, 0.000000f),
        new stars_type("PI^6 Orionis", 74.57496766386038f/15, 1.4505505846306124f, 0.000000f),
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
        new stars_type("1 Geminorum", 90.96828975357269f/15, 22.991653600620577f, 0.000000f),
        new stars_type("Propus", 93.4369219411265f/15, 22.60247193995005f, 0.000000f),
        new stars_type("Tejat", 95.98773443674125f/15, 22.356343965590995f, 0.000000f),
        new stars_type("Mebsuta", 101.10562608637606f/15, 24.87886180185512f, 0.000000f),
        new stars_type("Tau Geminorum", 107.87149066662214f/15, 30.160378254773047f, 0.000000f),
        new stars_type("Iota Geminorum", 111.51082460443274f/15, 27.53100911040583f, 0.000000f),
        new stars_type("Upsilon Geminorum", 114.1317257137815f/15, 26.655942385766544f, 0.000000f),
        new stars_type("Wasat", 110.00409175329717f/15, 21.706662711709033f, 0.000000f),
        new stars_type("Mekbuda", 106.04571780422269f/15, 20.29783595770087f, 0.000000f),
        new stars_type("Alhena", 99.15054509766834f/15, 16.34484748237026f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Nu Geminorum", 90.76460922102582f/15, 27.337930559242455f, 0.000000f),
        new stars_type("Mebsuta", 101.10562608637606f/15, 24.87886180185512f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Theta Geminorum", 103.18446664250823f/15, 33.68578499485399f, 0.000000f),
        new stars_type("Tau Geminorum", 107.87149066662214f/15, 30.160378254773047f, 0.000000f),
        new stars_type("Castor", 113.658355403213f/15, 31.610478805878525f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Pollux", 116.2065438829245f/15, 27.769179905166133f, 0.000000f),
        new stars_type("Upsilon Geminorum", 114.1317257137815f/15, 26.655942385766544f, 0.000000f),
        new stars_type("Kappa Geminorum", 116.2195504199731f/15, 24.147113064950293f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Xi Geminorum", 101.26134656822293f/15, 12.625353338104633f, 0.000000f),
        new stars_type("Lambda Geminorum A", 109.24057067532596f/15, 16.563537747132038f, 0.000000f),
        new stars_type("Wasat", 110.00409175329717f/15, 21.706662711709033f, 0.000000f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Gemini", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Auriga
        new stars_type("Constellation: Auriga", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Menkalinan", 90.24228333908634f/15, 44.98095102469142f, 0.000000f),
        new stars_type("Capella", 79.14364079496094f/15, 45.71962374693095f, 0.000000f),
        new stars_type("Zeta Aurigae", 75.59610120911057f/15, 40.80211121783874f, 0.000000f),
        new stars_type("Hassaleh", 74.00332027893697f/15, 32.983075382685826f, 0.000000f),
        new stars_type("Elnath", 81.57083529450648f/15, 28.641781623968633f, 0.000000f),
        new stars_type("Theta Aurigae", 90.00015170587346f/15, 37.17078761795807f, 0.000000f),
        new stars_type("Menkalinan", 90.24228333908634f/15, 44.98095102469142f, 0.000000f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Auriga", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Taurus
        new stars_type("Constellation: Taurus", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Elnath", 81.57083529450648f/15, 28.641781623968633f, 0.000000f),
        new stars_type("Tau Tauri", 70.7307662104994f/15, 22.730374363246664f, 0.000000f),
        new stars_type("Ain", 66.9641033230681f/15, 18.997222141099066f, 0.000000f),
        new stars_type("Delta3 Tauri A", 66.3543892058143f/15, 17.651605224364197f, 0.000000f),
        new stars_type("Ain", 66.9641033230681f/15, 18.997222141099066f, 0.000000f),
        new stars_type("Aldebaran", 69.01801469499635f/15, 16.23411618843057f, 0.000000f),
        new stars_type("Theta1 Tauri", 67.16864749026514f/15, 15.686429292514367f, 0.000000f),
        new stars_type("Theta2 Tauri", 67.36450513117276f/15, 15.77115967368875f, 0.000000f),
        new stars_type("Gamma Tauri", 65.05871186308119f/15, 15.374621742949984f, 0.000000f),
        new stars_type("Delta Tauri", 65.48336868603155f/15, 17.676407965779113f, 0.000000f),
        new stars_type("Delta3 Tauri A", 66.3543892058143f/15, 17.651605224364197f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Delta Tauri", 65.48336868603155f/15, 17.676407965779113f, 0.000000f),
        new stars_type("Pleiades", 56.888193674042256f/15, 24.045970935572253f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Aldebaran", 69.01801469499635f/15, 16.23411618843057f, 0.000000f),
        new stars_type("Zeta Tauri", 84.40509021913617f/15, 20.868944902381596f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Gamma Tauri", 65.05871186308119f/15, 15.374621742949984f, 0.000000f),
        new stars_type("Lambda Tauri", 60.42993339045191f/15, 12.459584850322635f, 0.000000f),
        new stars_type("Omicron Tauri", 51.13842206766417f/15, 8.781337495766852f, 0.000000f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Taurus", 0.000000f, 0.000000f, 0.000000f),
        #endregion

        #region Perseus
        new stars_type("Constellation: Perseus", 0.000000f, 0.000000f, 0.000000f),
        new stars_type("start", 0, 0, 0),
        new stars_type("Miram", 42.224965619464264f/15, 56.01172427262863f, 0.000000f),
        new stars_type("Gamma Persei", 45.75614659900449f/15, 53.43858663918914f, 0.000000f),
        new stars_type("Mirfak", 50.92279149212425f/15, 49.60333434834531f, 0.000000f),
        new stars_type("Delta Persei", 55.632024894592824f/15, 47.70524536439001f, 0.000000f),
        new stars_type("Epsilon Persei", 59.45970650843326f/15, 39.73453040143972f, 0.000000f),
        new stars_type("Menkib", 59.56279936581256f/15, 35.793576915725005f, 0.000000f),
        new stars_type("Zeta Persei", 58.21889712447938f/15, 31.959757150141655f, 0.000000f),
        new stars_type("Omicron Persei A", 55.756929776761055f/15, 32.31726250371995f, 0.000000f),
        new stars_type("end", 0, 0, 0),

        new stars_type("start", 0, 0, 0),
        new stars_type("Mirfak", 50.92279149212425f/15, 49.60333434834531f, 0.000000f),
        new stars_type("Algol", 46.82404733691389f/15, 40.73536995582118f, 0.000000f),
        new stars_type("Rho Persei", 46.32364598795892f/15, 38.5633139217738f, 0.000000f),
        new stars_type("16 Persei", 42.683207012298595f/15, 38.0457601625787f, 0.000000f),
        new stars_type("end", 0, 0, 0),
        new stars_type("Constellation: Perseus", 0.000000f, 0.000000f, 0.000000f),
        #endregion
        #endregion

        #region TODO


        #region Maybes
        #region Canis Major

        #endregion

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
        new stars_type("Alathfar", 0f/15, 0f, 5.13f),
        new stars_type("Gaia DR2 2112785156971655168", 0f/15, 0f, 5.81f),
        new stars_type("Vega", 0.000000f, 0.000000f, 0.09f),
        new stars_type("Epsilon² Lyrae", 0.000000f, 0.000000f, 4.63f),
        new stars_type("Epsilon¹ Lyrae", 0.000000f, 0.000000f, 4.72f),
        new stars_type("13 Lyrae", 0.000000f, 0.000000f, 3.92f),
        new stars_type("HD 166208", 0.000000f, 0.000000f, 5.13f),
        new stars_type("HD 169305", 0.000000f, 0.000000f, 5.09f),
        new stars_type("Kappa Lyrae", 0.000000f, 0.000000f, 4.47f),
        new stars_type("HD 166640", 0.000000f, 0.000000f, 5.72f),
        new stars_type("HD 166229", 0.000000f, 0.000000f, 5.66f),
        new stars_type("72 Herculis", 0.000000f, 0.000000f, 5.5f),
        new stars_type("68 Herculis", 0.000000f, 0.000000f, 4.72f),
        new stars_type("HD 158974", 0.000000f, 0.000000f, 5.78f),
        new stars_type("78 Herculis", 0.000000f, 0.000000f, 5.66f),
        new stars_type("HD 162555", 0.000000f, 0.000000f, 5.66f),
        new stars_type("HD 159501", 0.000000f, 0.000000f, 5.88f),
        new stars_type("V819 Herculis", 0.000000f, 0.000000f, 5.66f),
        new stars_type("c Herculis", 0.000000f, 0.000000f, 5.47f),
        new stars_type("d Herculis", 0.000000f, 0.000000f, 5.28f),
        new stars_type("53 Herculis", 0.000000f, 0.000000f, 5.41f),
        new stars_type("51 Herculis", 0.000000f, 0.000000f, 5.19f),
        new stars_type("HD 151203", 0.000000f, 0.000000f, 5.63f),
        new stars_type("s Herculis", 0.000000f, 0.000000f, 5.38f),
        new stars_type("54 Herculis", 0.000000f, 0.000000f, 5.47f),
        new stars_type("Cujam", 0.000000f, 0.000000f, 4.56f),
        new stars_type("Marsik", 0.000000f, 0.000000f, 5.16f),
        new stars_type("Gaia DR2 1199629656205894656", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Gaia DR2 4450016100717738880", 0.000000f, 0.000000f, 5.63f),
        new stars_type("9 Herculis", 0.000000f, 0.000000f, 5.59f),
        new stars_type("Lambda Serpentis", 0.000000f, 0.000000f, 4.53f),
        new stars_type("QY Serpentis", 0.000000f, 0.000000f, 5.53f),
        new stars_type("Pi Serpentis", 0.000000f, 0.000000f, 4.84f),
        new stars_type("Rho Serpentis", 0.000000f, 0.000000f, 4.84f),
        new stars_type("Iota Serpentis", 0.000000f, 0.000000f, 4.53f),
        new stars_type("Xi Coronae Borealis", 0.000000f, 0.000000f, 5.00f),
        new stars_type("HIP 79607", 0.000000f, 0.000000f, 5.34f),
        new stars_type("Gaia DR2 1378163509598334592", 0.000000f, 0.000000f, 4.38f),
        new stars_type("Nu¹ Coronae Borealis", 0.000000f, 0.000000f, 5.28f),
        new stars_type("Nu² Coronae Borealis", 0.000000f, 0.000000f, 5.50f),
        new stars_type("G Herculis", 0.000000f, 0.000000f, 4.47f),
        new stars_type("Kappa Coronae Borealis", 0.000000f, 0.000000f, 4.94f),
        new stars_type("Zeta Coronae Borealis A", 0.000000f, 0.000000f, 4.59f),
        new stars_type("Alkalurops", 0.000000f, 0.000000f, 4.38f),
        new stars_type("Nu² Boötis", 0.000000f, 0.000000f, 5.00f),
        new stars_type("Nu¹ Boötis", 0.000000f, 0.000000f, 5.13f),
        new stars_type("Mu Coronae Borealis", 0.000000f, 0.000000f, 5.22f),
        new stars_type("Upsilon Herculis", 0.000000f, 0.000000f, 4.69f),
        new stars_type("17 Draconis", 0.000000f, 0.000000f, 5.06f),
        new stars_type("Arrakis", 0.000000f, 0.000000f, 5.00f),
        new stars_type("HD 151613", 0.000000f, 0.000000f, 4.91f),
        new stars_type("Gaia DR2 1439121018358632832", 0.000000f, 0.000000f, 4.97f),
        new stars_type("HD 161693", 0.000000f, 0.000000f, 5.75f),
        new stars_type("36 Draconis", 0.000000f, 0.000000f, 5.06f),
        new stars_type("Phi Draconis", 0.000000f, 0.000000f, 4.19f),
        new stars_type("42 Draconis", 0.000000f, 0.000000f, 4.97f),
        new stars_type("Upsilon Draconis", 0.000000f, 0.000000f, 4.97f),
        new stars_type("Sigma Draconis", 0.000000f, 0.000000f, 4.78f),
        new stars_type("HIP 86201", 0.000000f, 0.000000f, 4.84f),
        new stars_type("Phi Draconis", 0.000000f, 0.000000f, 4.19f),
        new stars_type("27 Draconis", 0.000000f, 0.000000f, 5.22f),
        new stars_type("HD 175535", 0.000000f, 0.000000f, 5.06f),
        new stars_type("Gaia DR2 2146204847257954944", 0.000000f, 0.000000f, 5.25f),
        new stars_type("46 Draconis", 0.000000f, 0.000000f, 5.00f),
        new stars_type("45 Draconis", 0.000000f, 0.000000f, 4.88f),
        new stars_type("B draconis A", 0.000000f, 0.000000f, 5.00f),
        new stars_type("Omicron Draconis", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Kappa Cygni", 0.000000f, 0.000000f, 3.94f),
        new stars_type("Iota Cygni", 0.000000f, 0.000000f, 3.81f),
        new stars_type("Theta Cygni", 0.000000f, 0.000000f, 4.56f),
        new stars_type("Gaia DR2 2089092884718210432", 0.000000f, 0.000000f, 4.91f),
        new stars_type("Pi Draconis", 0.000000f, 0.000000f, 4.59f),
        new stars_type("20 Cygni", 0.000000f, 0.000000f, 5.16f),
        new stars_type("33 Cygni", 0.000000f, 0.000000f, 4.31f),
        new stars_type("Eta Cephei", 0.000000f, 0.000000f, 3.56f),
        new stars_type("HD 198084", 0.000000f, 0.000000f, 4.63f),
        new stars_type("Theta Cephei", 0.000000f, 0.000000f, 4.25f),
        new stars_type("44 Bootis", 0.000000f, 0.000000f, 4.88f),
        new stars_type("Gaia DR2 1211957655452767744", 0.000000f, 0.000000f, 4.5f),
        new stars_type("Xi Boötis A", 0.000000f, 0.000000f, 4.41f),
        new stars_type("Omicron Boötis", 0.000000f, 0.000000f, 4.75f),
        new stars_type("Gaia DR2 1186417202929115008", 0.000000f, 0.000000f, 3.86f),
        new stars_type("Pi¹ Boötis", 0.000000f, 0.000000f, 4.5f),
        new stars_type("Theta Bootis", 0.000000f, 0.000000f, 4.12f),
        new stars_type("Lambda Bootis", 0.000000f, 0.000000f, 4.19f),
        new stars_type("83 Ursae Majoris", 0.000000f, 0.000000f, 4.69f),
        new stars_type("25 Canum Venaticorum A", 0.000000f, 0.000000f, 4.84f),
        new stars_type("AW Canum Venaticorum", 0.000000f, 0.000000f, 4.78f),
        new stars_type("BH Canum Venaticorum", 0.000000f, 0.000000f, 5.00f),
        new stars_type("20 Canum Venaticorum", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Cor Caroli", 0.000000f, 0.000000f, 2.84f),
        new stars_type("Chara", 0.000000f, 0.000000f, 4.34f),
        new stars_type("5 Canum Venaticorum", 0.000000f, 0.000000f, 4.91f),
        new stars_type("Gaia DR2 1537396673318780544", 0.000000f, 0.000000f, 5.13f),
        new stars_type("6 Canum Venaticorum", 0.000000f, 0.000000f, 5.16f),
        new stars_type("Gaia DR2 1576850723937017216", 0.000000f, 0.000000f, 4.81f),
        new stars_type("14 Canum Venaticorum", 0.000000f, 0.000000f, 5.16f),
        new stars_type("Gamma Comae Berenices", 0.000000f, 0.000000f, 4.5f),
        new stars_type("Beta Comae Berenices", 0.000000f, 0.000000f, 4.34f),
        new stars_type("Alpha Comae Berenices", 0.000000f, 0.000000f, 4.41f),
        new stars_type("Gamma Comae Berenices", 0.000000f, 0.000000f, 4.5f),
        new stars_type("35 Comae Berenices A", 0.000000f, 0.000000f, 4.72f),
        new stars_type("40 Comae Berenices", 0.000000f, 0.000000f, 5.38f),
        new stars_type("41 Comae Berenices", 0.000000f, 0.000000f, 4.91f),
        new stars_type("31 Comae Berenices", 0.000000f, 0.000000f, 5.03f),
        new stars_type("26 Comae Berenices", 0.000000f, 0.000000f, 5.63f),
        new stars_type("27 Comae Berenices", 0.000000f, 0.000000f, 5.25f),
        new stars_type("36 Comae Berenices", 0.000000f, 0.000000f, 4.84f),
        new stars_type("21 Comae Berenices", 0.000000f, 0.000000f, 5.47f),
        new stars_type("17 Comae Berenices", 0.000000f, 0.000000f, 5.22f),
        new stars_type("16 Comae Berenices", 0.000000f, 0.000000f, 4.97f),
        new stars_type("13 Comae Berenices", 0.000000f, 0.000000f, 5.16f),
        new stars_type("14 Comae Berenices", 0.000000f, 0.000000f, 4.97f),
        new stars_type("12 Comae Berenices", 0.000000f, 0.000000f, 4.88f),
        new stars_type("7 Comae Berenices", 0.000000f, 0.000000f, 5.09f),
        new stars_type("HD 107325", 0.000000f, 0.000000f, 5.69f),
        new stars_type("24 Comae Berenices A", 0.000000f, 0.000000f, 5.19f),
        new stars_type("27 Comae Berenices", 0.000000f, 0.000000f, 5.25f),
        new stars_type("23 Comae Berenices", 0.000000f, 0.000000f, 4.78f),
        new stars_type("11 Comae Berenices", 0.000000f, 0.000000f, 4.88f),
        new stars_type("6 Comae Berenices", 0.000000f, 0.000000f,  5.09f),
        new stars_type("Rho Virginis", 0.000000f, 0.000000f, 4.88f),
        new stars_type("HIP 62325", 0.000000f, 0.000000f, 5.81f),
        new stars_type("d² Virginis", 0.000000f, 0.000000f, 5.28f),
        new stars_type("2 Comae Berenices A", 0.000000f, 0.000000f,  5.94f),
        new stars_type("6 Comae Berenices", 0.000000f, 0.000000f, 5.09f),
        new stars_type("93 Leonis", 0.000000f, 0.000000f,  4.63f),
        new stars_type("Omicron Virginis", 0.000000f, 0.000000f, 4.25f),
        new stars_type("Pi Virginis", 0.000000f, 0.000000f, 4.69f),
        new stars_type("Zaniah", 0.000000f, 0.000000f, 4.89f),
        new stars_type("Xi Virginis", 0.000000f, 0.000000f, 4.88f),
        new stars_type("Theta Virginis", 0.000000f, 0.000000f, 4.34f),
        new stars_type("110 Virginis", 0.000000f, 0.000000f, 4.53f),
        new stars_type("Gaia DR2 4421455530273467392", 0.000000f, 0.000000f, 4.84f),
        new stars_type("Gaia DR2 4419512109110088448", 0.000000f, 0.000000f, 4.97f),
        new stars_type("16 Librae", 0.000000f, 0.000000f, 4.53f),
        new stars_type("Delta Librae", 0.000000f, 0.000000f, 4.91f),
        new stars_type("Mu Librae", 0.000000f, 0.000000f, 5.31f),
        new stars_type("Zubeneschamali", 0.000000f, 0.000000f, 2.56f),
        new stars_type("Zubenelgenubi", 0.000000f, 0.000000f, 2.78f),
        new stars_type("Gaia DR2 4402474042571751424", 0.000000f, 0.000000f, 3.33f),
        new stars_type("Epsilon Serpentis", 0.000000f, 0.000000f, 3.75f),
        new stars_type("Unukalhai", 0.000000f, 0.000000f, 2.8f),
        new stars_type("Delta Serpentis", 0.000000f, 0.000000f, 3.86f),
        new stars_type("Beta Serpentis", 0.000000f, 0.000000f, 3.67f),
        new stars_type("Kappa Serpentis", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Gamma Serpentis", 0.000000f, 0.000000f, 3.94f),
        new stars_type("Iota Cygni", 0.000000f, 0.000000f, 3.81f),
        new stars_type("Kappa Cygni", 0.000000f, 0.000000f, 3.94f),
        new stars_type("Xi Ursae Majoris A", 0.000000f, 0.000000f, 4.0f),
        new stars_type("Alula Borealis", 0.000000f, 0.000000f, 3.63f),
        new stars_type("Mu Cephei", 0.000000f, 0.000000f, 3.91f),
        new stars_type("Gaia DR2 2198483880674251136", 0.000000f, 0.000000f, 4.06f),
        new stars_type("Xi Cephei A", 0.000000f, 0.000000f, 4.25f),
        new stars_type("19 Cephei", 0.000000f, 0.000000f, 5.09f),
        new stars_type("Pi Cephei A", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Gaia DR2 2272649822619848064", 0.000000f, 0.000000f, 4.19f),
        new stars_type("24 Cephei", 0.000000f, 0.000000f, 4.94f),
        new stars_type("HIP 111532", 0.000000f, 0.000000f, 5.16f),
        new stars_type("Delta Cephei", 0.000000f, 0.000000f, 4.25f),
        new stars_type("Beta Lacertae", 0.000000f, 0.000000f, 4.56f),
        new stars_type("Alpha Lacertae", 0.000000f, 0.000000f, 3.78f),
        new stars_type("4 Lacertae", 0.000000f, 0.000000f, 4.59f),
        new stars_type("Gaia DR2 2213911506281421824", 0.000000f, 0.000000f, 4.53f),
        new stars_type("Pi Cephei A", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Gaia DR2 2272649822619848064", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Rho Cassiopeiae", 0.000000f, 0.000000f, 4.66f),
        new stars_type("HD 224572B", 0.000000f, 0.000000f, 4.84f),
        new stars_type("Zeta Cassiopeiae", 0.000000f, 0.000000f, 3.61f),
        new stars_type("Achird", 0.000000f, 0.000000f, 3.58f),
        new stars_type("Upsilon¹ Cassiopeiae", 0.000000f, 0.000000f, 4.97f),
        new stars_type("Upsilon² Cassiopeiae", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Kappa Cassiopeiae", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Psi Cassiopeiae", 0.000000f, 0.000000f, 4.88f),
        new stars_type("Iota Cassiopeiae", 0.000000f, 0.000000f, 4.5f),
        new stars_type("48 Cassiopeiae", 0.000000f, 0.000000f, 4.53f),
        new stars_type("50 Cassiopeiae", 0.000000f, 0.000000f, 3.95f),
        new stars_type("Phi Andromedae", 0.000000f, 0.000000f, 4.22f),
        new stars_type("Upsilon Persei", 0.000000f, 0.000000f, 3.75f),
        new stars_type("Phi Persei", 0.000000f, 0.000000f, 3.97f),
        new stars_type("Upsilon Andromedae", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Tau Andromedae", 0.000000f, 0.000000f, 4.94f),
        new stars_type("HD 10307", 0.000000f, 0.000000f, 5.06f),
        new stars_type("Chi Andromedae", 0.000000f, 0.000000f, 5.16f),
        new stars_type("Almach", 0.000000f, 0.000000f, 2.23f),
        new stars_type("Gaia DR2 358813838633178368", 0.000000f, 0.000000f, 5.00f),
        new stars_type("64 Andromedae", 0.000000f, 0.000000f, 5.34f),
        new stars_type("65 Andromedae", 0.000000f, 0.000000f, 4.84f),
        new stars_type("Theta Persei", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Lambda Virginis", 0.000000f, 0.000000f, 4.53f),
        new stars_type("Gaia DR2 3613137118887389440", 0.000000f, 0.000000f, 5.25f),
        new stars_type("69 Virginis", 0.000000f, 0.000000f, 4.91f),
        new stars_type("89 Virginis", 0.000000f, 0.000000f, 5.13f),
        new stars_type("Psi Virginis", 0.000000f, 0.000000f, 4.81f),
        new stars_type("HD 110317J", 0.000000f, 0.000000f, 5.19f),
        new stars_type("Chi Virginis", 0.000000f, 0.000000f, 4.81f),
        new stars_type("Eta Corvi", 0.000000f, 0.000000f, 4.38f),
        new stars_type("Algorab", 0.000000f, 0.000000f, 2.94f),
        new stars_type("Gienah", 0.000000f, 0.000000f, 2.55f),
        new stars_type("Kraz", 0.000000f, 0.000000f, 2.8f),
        new stars_type("Epsilon Corvi", 0.000000f, 0.000000f, 3.17f),
        new stars_type("Alchiba", 0.000000f, 0.000000f, 4.09f),
        new stars_type("17 Crateris B", 0.000000f, 0.000000f, 5.03f),
        new stars_type("Iota Antilae", 0.000000f, 0.000000f, 4.75f),
        new stars_type("I Velorum", 0.000000f, 0.000000f, 4.41f),
        new stars_type("46 Centauri", 0.000000f, 0.000000f, 5.16f),
        new stars_type("Alpha Antilae", 0.000000f, 0.000000f, 4.41f),
        new stars_type("Ent Antliae", 0.000000f, 0.000000f, 5.28f),
        new stars_type("Q Velorum", 0.000000f, 0.000000f, 3.86f),
        new stars_type("Psi Velorum", 0.000000f, 0.000000f, 3.66f),
        new stars_type("Suhail", 0.000000f, 0.000000f, 2.33f),
        new stars_type("Naos", 0.000000f, 0.000000f, 2.13f),
        new stars_type("Tureis", 0.000000f, 0.000000f, 2.91f),
        new stars_type("Xi Puppis ", 0.000000f, 0.000000f, 3.5f),
        new stars_type("Pi Puppis ", 0.000000f, 0.000000f, 2.83f),
        new stars_type("Beta Pyxidis", 0.000000f, 0.000000f, 4.13f),
        new stars_type("Alpha Pyxidis ", 0.000000f, 0.000000f, 3.61f),
        new stars_type("Gamma Pyxidis ", 0.000000f, 0.000000f, 4.16f),
        new stars_type("30 Monocerotis", 0.000000f, 0.000000f, 3.89f),
        new stars_type("HIP 37229", 0.000000f, 0.000000f, 3.73f),
        new stars_type("11 Puppis", 0.000000f, 0.000000f, 4.31f),
        new stars_type("Theta Leporis", 0.000000f, 0.000000f, 4.69f),
        new stars_type("HD 6053", 0.000000f, 0.000000f, 4.53f),
        new stars_type("Xi1 Canis Majoris", 0.000000f, 0.000000f, 4.25f),
        new stars_type("Nu3 Canis Majoris", 0.000000f, 0.000000f, 4.59f),
        new stars_type("Alula Borealis", 0.000000f, 0.000000f, 3.63f),
        new stars_type("Xi Ursae Majoris A", 0.000000f, 0.000000f, 4.00f),
        new stars_type("Iota Leonis A", 0.000000f, 0.000000f, 4.03f),
        new stars_type("Sigma Leonis", 0.000000f, 0.000000f, 4.03f),
        new stars_type("Zavijava", 0.000000f, 0.000000f, 3.7f),
        new stars_type("Gaia DR2 3818309970064649984", 0.000000f, 0.000000f, 4.44f),
        new stars_type("Rho Leonis", 0.000000f, 0.000000f, 3.78f),
        new stars_type("31 Leonis", 0.000000f, 0.000000f, 4.5f),
        new stars_type("Subra", 0.000000f, 0.000000f, 3.63f),
        new stars_type("Iota Hydrae", 0.000000f, 0.000000f, 4.03f),
        new stars_type("Alpha Sextanis", 0.000000f, 0.000000f, 4.47f),
        new stars_type("Beta Sextanis", 0.000000f, 0.000000f, 5.03f),
        new stars_type("Upsilon Leonis", 0.000000f, 0.000000f, 4.44f),
        new stars_type("46 Leonis Minoris", 0.000000f, 0.000000f, 3.94f),
        new stars_type("Beta Leonis Minoris", 0.000000f, 0.000000f, 4.34f),
        new stars_type("21 Leonis Minoris", 0.000000f, 0.000000f, 4.53f),
        new stars_type("10 Leonis Minoris", 0.000000f, 0.000000f, 4.69f),
        new stars_type("Alterf", 0.000000f, 0.000000f, 4.41f),
        new stars_type("Kappa Leonis", 0.000000f, 0.000000f, 4.59f),
        new stars_type("Sigma2 Ursae Majoris A", 0.000000f, 0.000000f, 4.63f),
        new stars_type("5 Ursae Minoris", 0.000000f, 0.000000f, 4.38f),
        new stars_type("4 ursae Minoris", 0.000000f, 0.000000f, 4.94f),
        new stars_type("Psi1 Draconis A", 0.000000f, 0.000000f, 4.66f),
        new stars_type("Kappa Cephei", 0.000000f, 0.000000f, 4.34f),
        new stars_type("HIP 14632", 0.000000f, 0.000000f, 4.16f),
        new stars_type("Tau Persei", 0.000000f, 0.000000f, 4.06f),
        new stars_type("CE Camelopardelis", 0.000000f, 0.000000f, 4.66f),
        new stars_type("CS Camelopardelis", 0.000000f, 0.000000f, 4.28f),
        new stars_type("Alpha Camelopardali", 0.000000f, 0.000000f, 4.28f),
        new stars_type("Gamma Camelopardalis", 0.000000f, 0.000000f, 4.63f),
        new stars_type("HIP 25110", 0.000000f, 0.000000f, 5.19f),
        new stars_type("Gaia DR2 474610073947130368", 0.000000f, 0.000000f, 4.38f),
        new stars_type("Beta Camelopardalis", 0.000000f, 0.000000f, 4.16f),
        new stars_type("12 Lyncis", 0.000000f, 0.000000f, 4.88f),
        new stars_type("Delta Aurigae", 0.000000f, 0.000000f, 3.88f),
        new stars_type("Lambda Persei", 0.000000f, 0.000000f, 4.25f),
        new stars_type("48 Persei", 0.000000f, 0.000000f, 3.98f),
        new stars_type("Mu Persei", 0.000000f, 0.000000f, 4.28f),
        new stars_type("53 Persei", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Nu Persei", 0.000000f, 0.000000f, 3.86f),
        new stars_type("Sigma Persei", 0.000000f, 0.000000f, 4.47f),
        new stars_type("Psi Persei", 0.000000f, 0.000000f, 4.28f),
        new stars_type("Omega Persei", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Epsilon Aurigae", 0.000000f, 0.000000f, 3.14f),
        new stars_type("58 Persei", 0.000000f, 0.000000f, 4.38f),
        new stars_type("Eta Aurigae", 0.000000f, 0.000000f, 3.11f),
        new stars_type("Nu Aurigae", 0.000000f, 0.000000f, 4.13f),
        new stars_type("Tau Aurigae", 0.000000f, 0.000000f, 4.66f),
        new stars_type("Upsilon Aurigae", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Kappa1 Tauri", 0.000000f, 0.000000f, 4.25f),
        new stars_type("37 Tauri", 0.000000f, 0.000000f, 4.5f),
        new stars_type("Upsilon Tauri", 0.000000f, 0.000000f, 4.34f),
        new stars_type("Mercury", 0.000000f, 0.000000f, -0.51f),
        new stars_type("Epsilon Arietis", 0.000000f, 0.000000f, 4.63f),
        new stars_type("Botein", 0.000000f, 0.000000f, 4.5f),
        new stars_type("Zeta Arietis", 0.000000f, 0.000000f, 4.88f),
        new stars_type("Pi Aurigae", 0.000000f, 0.000000f, 4.28f),
        new stars_type("Kappa Aurigae", 0.000000f, 0.000000f, 4.47f),
        new stars_type("136 Tauri", 0.000000f, 0.000000f, 4.53f),
        new stars_type("139 Tauri", 0.000000f, 0.000000f, 4.78f),
        new stars_type("Tegmine", 0.000000f, 0.000000f, 4.75f),
        new stars_type("Procyon", 0.000000f, 0.000000f, 0.46f),
        new stars_type("Gomeisa", 0.000000f, 0.000000f, 2.84f),
        new stars_type("Eta Leporis", 0.000000f, 0.000000f, 3.78f),
        new stars_type("Zeta Leporis", 0.000000f, 0.000000f, 3.56f),
        new stars_type("Arneb", 0.000000f, 0.000000f, 2.64f),
        new stars_type("Delta Leporis", 0.000000f, 0.000000f, 3.92f),
        new stars_type("Gamma Leporis", 0.000000f, 0.000000f, 3.69f),
        new stars_type("Nihal", 0.000000f, 0.000000f, 2.95f),
        new stars_type("Mu Leporis", 0.000000f, 0.000000f, 3.25f),
        new stars_type("Lambda Leporis", 0.000000f, 0.000000f, 4.19f),
        new stars_type("Kappa Leporis", 0.000000f, 0.000000f, 4.31f),
        new stars_type("Iota Leporis", 0.000000f, 0.000000f, 4.41f),
        new stars_type("Eta Orionis", 0.000000f, 0.000000f, 3.28f),
        new stars_type("Rho Orionis", 0.000000f, 0.000000f, 4.63f)




#endregion
    };

    /// <summary>
    /// The constant conversion rate from degrees to radians.
    /// </summary>
    private const float deg2rad = 0.0174533f;
    #endregion

    #region Constellations
    /// <summary>
    /// The prefab that will be spawned to create constellation lines.
    /// </summary>
    [SerializeField]
    [Tooltip("The constellation lines prefab")]
    private GameObject constellationLines;

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
    #endregion

    #region Functions
    /// <summary>
    /// Initializes necessary values.
    /// </summary>
    void Awake()
    {
        InitializeStars();
    }

    /// <summary>
    /// Initializes the stars.
    /// </summary>
    private void InitializeStars()
    {
        ps = GetComponent<ParticleSystem>();
        particleStars = new Particle[ps.main.maxParticles];
        maxParticles = ps.main.maxParticles;

        Invoke("CreateParticleField", 0.05f);
        Invoke("SetRotation", 0.06f);
    }

    /// <summary>
    /// sets the rotation of the sphere to the time and latitude of Peoria on April 22nd at 9 p.m.
    /// </summary>
    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(40.6936f, 0, -28.9f));
    }

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
        ps.GetParticles(particleStars);

        // Assigns all of the stars to their places
        for (int a = 0; a < star_Database.Length; a++)
        {
            Vector3 pos = Vector3.zero;
            CalculatePlacement(a, ref pos);

            bool nameStartEnd = star_Database[a].name == "start" || star_Database[a].name == "end";

            CheckIfConstellation(a);

            SpawnStar(a, nameStartEnd, pos);

            if (isConstellation)
            {
                SetLinePoints(ref constellationLine, star_Database[a].name, ref starPositions, pos);
            }
        }

        // Sets the values of the particles
        ps.SetParticles(particleStars, maxParticles);
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

            if (isConstellation)
            {
                currentConstellation = ParseConstellationName(a);

                constellations.Add(currentConstellation, new List<LineRenderer>());
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
        if (!alreadyUsedNames.Contains(star_Database[a].name) && !nameStartEnd)
        {
            // Sets the values of the star
            particleStars[alreadyUsedNames.Count].position = pos;
            particleStars[alreadyUsedNames.Count].remainingLifetime = Mathf.Infinity;
            particleStars[alreadyUsedNames.Count].startSize = 2.0f * (8.0f - star_Database[a].mag);

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
                constellationLine.SetPosition(i, starPositions[i]);
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
        GameObject tempRef = Instantiate(constellationLines);
        tempRef.transform.parent = transform;
        constellationLine = tempRef.GetComponent<LineRenderer>();
        constellationLine.positionCount = 0;
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
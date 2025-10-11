using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using Syncfusion.Maui.Core;
using System.Collections.ObjectModel;

namespace TPERS.View.Pages.Components.Modal;

public partial class IconSelecterModal : Popup
{
	private readonly string[] iconCodes = [
		  "\u0021", "\u0023", "\u0024", "\u0025", "\u002a", "\u002b", "\u002d",
		  "\u0030", "\u0031", "\u0032", "\u0033", "\u0034", "\u0035", "\u0036", "\u0037",
		  "\u0038", "\u0039", "\u003c", "\u003d", "\u003e", "\u003f", "\u0040", "\u0041",
		  "\u0042", "\u0043", "\u0044", "\u0045", "\u0046", "\u0047", "\u0048", "\u0049",
		  "\u004a", "\u004b", "\u004c", "\u004d", "\u004e", "\u004f", "\u0050", "\u0051",
		  "\u0052", "\u0053", "\u0054", "\u0055", "\u0056", "\u0057", "\u0058", "\u0059",
		  "\u005a", "\u0022", "\ue005", "\ue006", "\ue00d", "\ue012", "\ue03f", "\ue040",
		  "\ue041", "\ue059", "\ue05a", "\ue05b", "\ue05c", "\ue05d", "\ue05e", "\ue05f",
		  "\ue061", "\ue062", "\ue063", "\ue064", "\ue065", "\ue066", "\ue067", "\ue068",
		  "\ue069", "\ue06a", "\ue06b", "\ue06c", "\ue06d", "\ue06e", "\ue06f", "\ue070",
		  "\ue071", "\ue072", "\ue073", "\ue074", "\ue075", "\ue076", "\ue085", "\ue086",
		  "\ue097", "\ue098", "\ue09a", "\ue0a9", "\ue0ac", "\ue0b4", "\ue0b7", "\ue0bb",
		  "\ue0d8", "\ue0df", "\ue0e3", "\ue0e4", "\ue131", "\ue139", "\ue13a", "\ue13b",
		  "\ue13c", "\ue140", "\ue152", "\ue163", "\ue169", "\ue16d", "\ue17b", "\ue184",
		  "\ue185", "\ue18f", "\ue19a", "\ue19b", "\ue1a8", "\ue1b0", "\ue1bc", "\ue1c4",
		  "\ue1c8", "\ue1d3", "\ue1d5", "\ue1d7", "\ue1ed", "\ue1f3", "\ue1f6", "\ue1fe",
		  "\ue209", "\ue221", "\ue222", "\ue22d", "\ue23d", "\ue289", "\ue29c", "\ue2b7",
		  "\ue2bb", "\ue2c5", "\ue2ca", "\ue2cd", "\ue2ce", "\ue2e6", "\ue2eb", "\ue31e",
		  "\ue3af", "\ue3b1", "\ue3b2", "\ue3f5", "\ue43c", "\ue445", "\ue447", "\ue448",
		  "\ue46c", "\ue473", "\ue476", "\ue477", "\ue47a", "\ue47b", "\ue490", "\ue494",
		  "\ue4a5", "\ue4a8", "\ue4a9", "\ue4aa", "\ue4ab", "\ue4ac", "\ue4ad", "\ue4af",
		  "\ue4b0", "\ue4b3", "\ue4b5", "\ue4b6", "\ue4b7", "\ue4b8", "\ue4b9", "\ue4ba",
		  "\ue4bb", "\ue4bc", "\ue4bd", "\ue4be", "\ue4bf", "\ue4c0", "\ue4c1", "\ue4c2",
		  "\ue4c3", "\ue4c4", "\ue4c5", "\ue4c6", "\ue4c7", "\ue4c8", "\ue4c9", "\ue4ca",
		  "\ue4cb", "\ue4cc", "\ue4ce", "\ue4cf", "\ue4d0", "\ue4d1", "\ue4d2", "\ue4d3",
		  "\ue4d4", "\ue4d5", "\ue4d6", "\ue4d7", "\ue4d8", "\ue4d9", "\ue4da", "\ue4db",
		  "\ue4dc", "\ue4dd", "\ue4de", "\ue4e0", "\ue4e1", "\ue4e2", "\ue4e3", "\ue4e4",
		  "\ue4e5", "\ue4e6", "\ue4e8", "\ue4e9", "\ue4ea", "\ue4eb", "\ue4ed", "\ue4ef",
		  "\ue4f0", "\ue4f1", "\ue4f2", "\ue4f3", "\ue4f4", "\ue4f5", "\ue4f6", "\ue4f7",
		  "\ue4f8", "\ue4f9", "\ue4fa", "\ue4fb", "\ue4fc", "\ue4fd", "\ue4fe", "\ue4ff",
		  "\ue500", "\ue501", "\ue502", "\ue503", "\ue507", "\ue508", "\ue509", "\ue50a",
		  "\ue50b", "\ue50c", "\ue50d", "\ue50e", "\ue50f", "\ue510", "\ue511", "\ue512",
		  "\ue513", "\ue514", "\ue515", "\ue516", "\ue517", "\ue518", "\ue519", "\ue51a",
		  "\ue51b", "\ue51c", "\ue51d", "\ue51e", "\ue51f", "\ue520", "\ue521", "\ue522",
		  "\ue523", "\ue524", "\ue525", "\ue527", "\ue528", "\ue529", "\ue52a", "\ue52b",
		  "\ue52c", "\ue52d", "\ue52e", "\ue52f", "\ue532", "\ue533", "\ue534", "\ue535",
		  "\ue536", "\ue537", "\ue538", "\ue539", "\ue53a", "\ue53b", "\ue53c", "\ue53d",
		  "\ue53e", "\ue53f", "\ue540", "\ue541", "\ue542", "\ue543", "\ue544", "\ue545",
		  "\ue546", "\ue547", "\ue548", "\ue549", "\ue54a", "\ue54b", "\ue54c", "\ue54d",
		  "\ue54e", "\ue54f", "\ue551", "\ue552", "\ue553", "\ue554", "\ue555", "\ue556",
		  "\ue557", "\ue558", "\ue55a", "\ue55b", "\ue55c", "\ue55d", "\ue55e", "\ue55f",
		  "\ue560", "\ue561", "\ue562", "\ue563", "\ue564", "\ue565", "\ue566", "\ue567",
		  "\ue568", "\ue569", "\ue56a", "\ue56b", "\ue56c", "\ue56d", "\ue56e", "\ue56f",
		  "\ue571", "\ue572", "\ue573", "\ue574", "\ue576", "\ue577", "\ue578", "\ue579",
		  "\ue57a", "\ue57b", "\ue57c", "\ue57d", "\ue57e", "\ue57f", "\ue580", "\ue581",
		  "\ue582", "\ue583", "\ue584", "\ue585", "\ue586", "\ue587", "\ue589", "\ue58a",
		  "\ue58b", "\ue58c", "\ue58d", "\ue58e", "\ue58f", "\ue591", "\ue592", "\ue593",
		  "\ue594", "\ue595", "\ue596", "\ue597", "\ue598", "\ue599", "\ue59a", "\ue59c",
		  "\ue59d", "\ue5a0", "\ue5a1", "\ue5a9", "\ue5aa", "\ue5af", "\ue5b4", "\ue678",
		  "\ue67a", "\ue682", "\ue68f", "\ue691", "\ue695", "\ue696", "\ue697", "\ue698",
		  "\ue699", "\ue69a", "\ue69b", "\ue790", "\ue807", "\ue80a", "\ue816", "\ue81b",
		  "\ue81c", "\ue81d", "\ue820", "\uf000", "\uf001", "\uf002", "\u2665", "\u2b50",
		  "\uf007", "\uf008", "\uf009", "\uf00a", "\uf00b", "\u2713", "\u00d7", "\uf00e",
		  "\uf010", "\u23fb", "\uf012", "\u2699", "\uf015", "\uf017", "\uf018", "\uf019",
		  "\uf01c", "\u21bb", "\uf021", "\uf022", "\uf023", "\uf024", "\uf025", "\uf026",
		  "\uf027", "\uf028", "\uf029", "\uf02a", "\uf02b", "\uf02c", "\uf02d", "\uf02e",
		  "\u2399", "\uf030", "\uf031", "\uf032", "\uf033", "\uf034", "\uf035", "\uf036",
		  "\uf037", "\uf038", "\uf039", "\uf03a", "\uf03b", "\uf03c", "\uf03d", "\uf03e",
		  "\uf041", "\u25d0", "\uf043", "\uf044", "\uf047", "\uf048", "\u23ee", "\u23ea",
		  "\u25b6", "\u23f8", "\u23f9", "\u23e9", "\u23ed", "\uf051", "\u23cf", "\u2329",
		  "\u232a", "\uf055", "\uf056", "\uf057", "\uf058", "\uf059", "\uf05a", "\uf05b",
		  "\uf05e", "\u2190", "\u2192", "\u2191", "\u2193", "\uf064", "\uf065", "\uf066",
		  "\u2013", "\uf06a", "\uf06b", "\uf06c", "\uf06d", "\uf06e", "\uf070", "\u26a0",
		  "\uf072", "\uf073", "\uf074", "\uf075", "\uf076", "\uf077", "\uf078", "\uf079",
		  "\uf07a", "\uf07b", "\uf07c", "\uf07d", "\uf07e", "\uf080", "\uf083", "\uf084",
		  "\uf085", "\uf086", "\uf089", "\uf08b", "\uf08d", "\uf08e", "\uf090", "\uf091",
		  "\uf093", "\uf094", "\uf095", "\uf098", "\uf09c", "\uf09d", "\uf09e", "\uf0a0",
		  "\uf0a1", "\uf0a3", "\uf0a4", "\uf0a5", "\u261d", "\uf0a7", "\uf0a8", "\uf0a9",
		  "\uf0aa", "\uf0ab", "\uf0ac", "\uf0ad", "\uf0ae", "\uf0b0", "\uf0b1", "\uf0b2",
		  "\uf0c0", "\uf0c1", "\u2601", "\uf0c3", "\u2700", "\uf0c5", "\uf0c6", "\uf0c7",
		  "\u25a0", "\uf0c9", "\uf0ca", "\uf0cb", "\uf0cc", "\uf0cd", "\uf0ce", "\uf0d0",
		  "\u26df", "\uf0d6", "\uf0d7", "\uf0d8", "\uf0d9", "\uf0da", "\uf0db", "\uf0dc",
		  "\uf0dd", "\uf0de", "\u2709", "\u21ba", "\uf0e3", "\u26a1", "\uf0e8", "\uf0e9",
		  "\uf0ea", "\uf0eb", "\u21c4", "\uf0ed", "\uf0ee", "\uf0f0", "\uf0f1", "\uf0f2",
		  "\uf0a2", "\uf0f4", "\uf0f8", "\uf0f9", "\uf0fa", "\uf0fb", "\uf0fc", "\uf0fd",
		  "\uf0fe", "\u00ab", "\u00bb", "\uf102", "\uf103", "\u2039", "\u203a", "\u2303",
		  "\u2304", "\uf109", "\uf10a", "\uf10b", "\u201c", "\u201d", "\uf110", "\u25cf",
		  "\uf118", "\u2639", "\uf11a", "\uf11b", "\u2328", "\uf11e", "\uf120", "\uf121",
		  "\uf122", "\uf124", "\uf125", "\uf126", "\uf127", "\uf129", "\uf12b", "\uf12c",
		  "\uf12d", "\uf12e", "\uf130", "\uf131", "\uf132", "\uf133", "\uf134", "\uf135",
		  "\uf137", "\uf138", "\uf139", "\uf13a", "\u2693", "\uf13e", "\uf140", "\uf141",
		  "\uf142", "\uf143", "\uf01d", "\uf145", "\uf146", "\uf148", "\uf149", "\u2611",
		  "\uf14b", "\uf14c", "\uf045", "\uf14e", "\uf150", "\uf151", "\uf152", "\u20ac",
		  "\u00a3", "\u20a8", "\u00a5", "\u20bd", "\u20a9", "\uf016", "\uf0f6", "\uf15d",
		  "\uf15e", "\uf160", "\uf161", "\uf162", "\uf163", "\uf087", "\uf088", "\uf175",
		  "\uf176", "\uf177", "\uf178", "\uf182", "\uf183", "\u2600", "\u23fe", "\uf187",
		  "\uf188", "\uf191", "\uf192", "\uf193", "\u20a4", "\uf197", "\uf199", "\uf19c",
		  "\uf19d", "\uf1ab", "\uf1ac", "\uf0f7", "\uf1ae", "\uf1b0", "\uf1b2", "\uf1b3",
		  "\u2672", "\uf1b9", "\uf1ba", "\uf1bb", "\uf1c0", "\uf1c1", "\uf1c2", "\uf1c3",
		  "\uf1c4", "\uf1c5", "\uf1c6", "\uf1c7", "\uf1c8", "\uf1c9", "\uf1cd", "\uf1ce",
		  "\uf1d8", "\uf1da", "\uf1dc", "\u00b6", "\uf1de", "\uf1e0", "\uf1e1", "\uf1e2",
		  "\u26bd", "\uf1e4", "\uf1e5", "\uf1e6", "\uf1ea", "\uf1eb", "\uf1ec", "\uf1f6",
		  "\uf1f8", "\u00a9", "\uf1fb", "\uf1fc", "\uf1fd", "\uf1fe", "\uf200", "\uf201",
		  "\uf204", "\uf205", "\uf206", "\uf207", "\uf20a", "\u20aa", "\uf217", "\uf218",
		  "\u2666", "\uf21a", "\uf21b", "\uf21c", "\uf21d", "\uf21e", "\u2640", "\u2642",
		  "\u263f", "\u26a5", "\u26a7", "\u26a2", "\u26a3", "\u26a4", "\u26a6", "\u26a8",
		  "\u26a9", "\u26b2", "\uf22d", "\uf233", "\uf234", "\uf235", "\uf236", "\uf238",
		  "\uf239", "\uf240", "\uf241", "\uf242", "\uf243", "\uf244", "\uf245", "\uf246",
		  "\uf247", "\uf248", "\uf249", "\uf24d", "\u2696", "\uf251", "\uf252", "\u231b",
		  "\u23f3", "\uf255", "\u270b", "\uf257", "\uf258", "\uf259", "\uf25a", "\u270c",
		  "\u2122", "\u00ae", "\uf26c", "\uf271", "\uf272", "\uf273", "\uf274", "\uf275",
		  "\uf276", "\uf277", "\uf278", "\uf27a", "\uf28b", "\uf28d", "\uf290", "\uf291",
		  "\uf29a", "\uf29d", "\uf29e", "\uf2a0", "\uf2a1", "\uf2a2", "\uf2a3", "\uf2a4",
		  "\uf2a7", "\uf2a8", "\uf2b4", "\uf2b5", "\uf2b6", "\uf2b9", "\uf2bb", "\uf2bd",
		  "\uf2c1", "\uf2c2", "\uf2c7", "\uf2c8", "\uf2c9", "\uf2ca", "\uf2cb", "\uf2cc",
		  "\uf2cd", "\uf2ce", "\uf2d0", "\uf2d1", "\uf2d2", "\u274e", "\uf2db", "\u2744",
		  "\uf1b1", "\uf0f5", "\uf2ea", "\uf014", "\uf2f1", "\u23f1", "\uf2f5", "\uf2f6",
		  "\uf2f9", "\uf2fe", "\uf302", "\u270f", "\uf304", "\uf305", "\uf306", "\uf309",
		  "\uf30a", "\uf30b", "\uf30c", "\u2b23", "\uf31c", "\uf31e", "\uf328", "\u2194",
		  "\u2195", "\u23f0", "\uf01a", "\uf190", "\uf18e", "\uf01b", "\uf35d", "\u2197",
		  "\uf362", "\uf363", "\uf386", "\uf387", "\uf108", "\uf3a5", "\u2935", "\u2934",
		  "\uf3c1", "\uf3c5", "\uf3c9", "\uf3cd", "\uf3ce", "\uf3cf", "\uf3d1", "\uf3dd",
		  "\uf3e0", "\uf112", "\uf3ed", "\uf3fa", "\uf3fb", "\uf3ff", "\uf2d4", "\uf422",
		  "\uf424", "\uf432", "\u26be", "\uf434", "\uf436", "\uf439", "\u265d", "\uf43c",
		  "\u265a", "\u265e", "\u265f", "\u265b", "\u265c", "\uf44b", "\uf44e", "\uf450",
		  "\uf453", "\uf458", "\u2b1b", "\uf45d", "\uf45f", "\uf461", "\uf462", "\uf466",
		  "\uf468", "\uf469", "\uf46a", "\uf46b", "\uf46c", "\uf46d", "\uf470", "\uf471",
		  "\uf472", "\uf474", "\uf477", "\uf478", "\uf479", "\u24bd", "\uf47f", "\uf481",
		  "\uf482", "\uf484", "\uf485", "\uf486", "\uf487", "\uf48b", "\uf48d", "\uf48e",
		  "\uf490", "\uf491", "\uf492", "\uf493", "\uf494", "\uf496", "\uf497", "\uf49e",
		  "\uf27b", "\uf4b3", "\uf4b8", "\uf4b9", "\uf4ba", "\uf4bd", "\uf4be", "\uf4c0",
		  "\uf4c1", "\uf4c2", "\uf4c4", "\uf4cd", "\uf4ce", "\uf4d3", "\uf4d6", "\uf4d7",
		  "\uf4d8", "\uf4d9", "\uf4da", "\uf4db", "\uf4de", "\uf4df", "\uf4e2", "\uf4e3",
		  "\uf4fb", "\uf4fc", "\uf4fd", "\uf4fe", "\uf4ff", "\uf500", "\uf501", "\uf502",
		  "\uf503", "\uf504", "\uf505", "\uf4fa", "\uf507", "\uf508", "\uf509", "\uf515",
		  "\uf516", "\uf517", "\uf518", "\uf519", "\uf51a", "\uf51b", "\uf51c", "\u26ea",
		  "\uf51e", "\uf51f", "\uf520", "\uf521", "\uf522", "\u2684", "\u2683", "\u2680",
		  "\u2685", "\u2682", "\u2681", "\u00f7", "\uf52a", "\uf52b", "\uf52d", "\uf52e",
		  "\u26fd", "\uf530", "\uf532", "\uf533", "\uf535", "\uf537", "\uf538", "\uf539",
		  "\uf53a", "\uf53b", "\uf53c", "\uf53d", "\uf53e", "\uf53f", "\uf540", "\uf542",
		  "\uf543", "\uf544", "\uf545", "\uf546", "\uf547", "\uf548", "\uf549", "\uf54a",
		  "\uf54b", "\uf54c", "\uf54d", "\uf54e", "\uf54f", "\uf550", "\uf551", "\uf552",
		  "\uf553", "\uf554", "\uf555", "\uf556", "\uf557", "\uf558", "\uf559", "\u232b",
		  "\uf55b", "\uf55c", "\uf55d", "\uf55e", "\uf55f", "\uf560", "\uf561", "\uf562",
		  "\uf563", "\uf564", "\uf565", "\uf566", "\uf567", "\uf568", "\uf569", "\uf56a",
		  "\uf56b", "\uf56c", "\uf56d", "\uf56e", "\uf56f", "\uf570", "\uf571", "\uf572",
		  "\uf573", "\uf574", "\uf575", "\uf576", "\uf577", "\uf578", "\uf579", "\uf57a",
		  "\uf57b", "\uf57c", "\uf57d", "\uf57e", "\uf57f", "\uf580", "\uf581", "\uf582",
		  "\uf583", "\uf584", "\uf585", "\uf586", "\uf587", "\uf588", "\uf589", "\uf58a",
		  "\uf58b", "\uf58c", "\ue307", "\uf58e", "\uf590", "\uf591", "\uf593", "\uf594",
		  "\uf595", "\uf596", "\uf597", "\uf598", "\uf599", "\uf59a", "\uf59b", "\uf59c",
		  "\uf59d", "\uf59f", "\uf5a0", "\uf5a1", "\uf5a2", "\uf5a4", "\uf5a5", "\uf5a6",
		  "\uf5a7", "\uf5aa", "\uf5ab", "\u2712", "\u2711", "\uf5ae", "\uf5af", "\uf5b0",
		  "\uf5b1", "\uf5b3", "\uf5b4", "\uf5b6", "\uf5b7", "\uf5b8", "\uf5ba", "\uf5bb",
		  "\uf5bc", "\uf5bd", "\uf5bf", "\uf5c0", "\uf5c1", "\uf5c2", "\uf5c3", "\uf5c4",
		  "\uf5c5", "\uf5c7", "\uf5c8", "\uf5c9", "\uf5ca", "\uf5cd", "\uf5ce", "\uf5d0",
		  "\uf5d1", "\u269b", "\uf5d7", "\uf5da", "\uf5dc", "\uf5de", "\uf5df", "\uf5e1",
		  "\uf5e4", "\uf5e7", "\uf5eb", "\ue2c7", "\uf5fc", "\uf5fd", "\uf601", "\uf604",
		  "\uf610", "\uf613", "\uf619", "\uf61f", "\uf621", "\uf624", "\uf3fd", "\uf629",
		  "\uf0e4", "\uf62e", "\uf62f", "\uf630", "\uf637", "\uf63b", "\uf63c", "\uf641",
		  "\u2625", "\uf647", "\uf64a", "\uf64f", "\uf651", "\uf653", "\u271d", "\u2638",
		  "\uf658", "\uf65d", "\uf65e", "\uf662", "\uf664", "\uf665", "\uf666", "\uf669",
		  "\uf66a", "\uf66b", "\u262c", "\uf66f", "\uf674", "\uf676", "\uf678", "\uf679",
		  "\uf67b", "\u262e", "\uf67f", "\uf681", "\uf682", "\uf683", "\uf684", "\uf687",
		  "\uf688", "\uf689", "\uf696", "\uf698", "\u262a", "\u2721", "\uf69b", "\uf6a0",
		  "\u26e9", "\uf6a7", "\uf6a9", "\u262f", "\uf6b6", "\uf6b7", "\u26fa", "\uf6be",
		  "\uf6c0", "\uf6c3", "\u26c5", "\uf6c8", "\uf6cf", "\uf6d1", "\uf6d3", "\uf6d5",
		  "\uf6d7", "\uf6d9", "\uf6dd", "\u270a", "\uf6e2", "\uf6e3", "\uf6e6", "\uf6e8",
		  "\uf6ec", "\uf6ed", "\uf6f0", "\uf6f1", "\u20b4", "\uf6fa", "\uf6fc", "\uf6ff",
		  "\uf700", "\uf70b", "\uf70c", "\uf70e", "\u2620", "\uf715", "\uf717", "\uf71e",
		  "\uf722", "\uf728", "\uf729", "\uf72b", "\uf72e", "\uf72f", "\uf73b", "\uf73c",
		  "\u26c6", "\uf740", "\uf743", "\uf747", "\uf74d", "\uf751", "\uf752", "\u2604",
		  "\uf756", "\uf75a", "\uf75b", "\uf75e", "\uf75f", "\uf769", "\uf76b", "\uf76c",
		  "\uf76f", "\uf770", "\uf772", "\uf773", "\uf77c", "\uf77d", "\u2623", "\uf781",
		  "\uf783", "\uf784", "\uf786", "\uf787", "\uf788", "\uf78c", "\uf793", "\uf794",
		  "\uf796", "\uf79c", "\uf79f", "\uf7a0", "\uf7a2", "\uf7a4", "\uf7a5", "\uf7a6",
		  "\uf7a9", "\uf7aa", "\uf7ab", "\uf7ad", "\uf7ae", "\uf7b5", "\u2615", "\uf7b9",
		  "\u2622", "\uf7bd", "\uf7bf", "\uf7c0", "\uf7c2", "\uf7c4", "\uf7c5", "\u26f7",
		  "\uf7ca", "\uf7cc", "\uf7cd", "\uf7ce", "\u2603", "\uf7d2", "\u20b8", "\uf7d8",
		  "\uf7d9", "\ue0cf", "\uf7e4", "\uf7e5", "\uf7e6", "\uf7ec", "\uf7ef", "\uf7f2",
		  "\uf7f3", "\uf7f5", "\uf7f7", "\uf7fa", "\uf7fb", "\uf802", "\uf805", "\uf806",
		  "\uf807", "\uf80d", "\uf80f", "\uf810", "\uf812", "\uf815", "\uf816", "\uf818",
		  "\uf81d", "\uf827", "\uf828", "\uf829", "\uf82a", "\uf82f", "\uf83e", "\uf84a",
		  "\uf84c", "\uf850", "\uf853", "\uf85e", "\uf863", "\uf86d", "\uf879", "\uf87b",
		  "\uf87c", "\uf87d", "\uf881", "\uf882", "\uf884", "\uf885", "\uf886", "\uf887",
		  "\uf891", "\uf897", "\uf8c0", "\uf8c1", "\uf8cc", "\uf8d7", "\uf8d9", "\uf8ef",
		  "\uf8ff", "\u221e"
	];

	private readonly Color[] iconColors = 
	[
        Color.FromArgb("00FF00"),
        Color.FromArgb("9ACD32"),
        Color.FromArgb("FFFF00"),
        Color.FromArgb("FFD700"),
        Color.FromArgb("FFA500"),
        Color.FromArgb("FF4500"),
        Color.FromArgb("FF0000"),
        Color.FromArgb("C71585"),
        Color.FromArgb("800080"),
        Color.FromArgb("4B0082"),
        Color.FromArgb("0000FF"),
        Color.FromArgb("00CED1")
    ];

	public ObservableCollection<string> IconList { get; } = new ObservableCollection<string>();
	public ObservableCollection<Color> ColorsList { get; } = new ObservableCollection<Color>();

	public string selectedIconCode;
	public Color selectedColor = Color.FromArgb("FFFFFF");

    public IconSelecterModal()
	{
		InitializeComponent();
		GerateIcons();

        BindingContext = this;
    }

	private void GerateIcons()
	{
        foreach (var c in iconCodes)
            IconList.Add(c);

        foreach (var d in iconColors)
            ColorsList.Add(d);
    }

	public void SelectIcon(object sender, SelectionChangedEventArgs e)
	{
		selectedIconCode = e.CurrentSelection.FirstOrDefault() as string;

        icon.iconImage = selectedIconCode;
    }

	public void SelectColor(object sender, SelectionChangedEventArgs e)
	{
		selectedColor = (Color)e.CurrentSelection.FirstOrDefault();

		icon.iconColor = selectedColor;
    }

    private async void CancelButton(object sender, EventArgs e)
    {
		await CloseAsync();
    }
    private async void SaveButton(object sender, EventArgs e)
    {
		await CloseAsync();
    }
}
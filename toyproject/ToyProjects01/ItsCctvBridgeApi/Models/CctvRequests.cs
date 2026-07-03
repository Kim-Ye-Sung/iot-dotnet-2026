namespace ItsCctvBridgeApi.Models
{
    public class CctvRequests
    {
        public string RoadType { get; set; } = "ex"; // 고속도로 기본 선택

        public int CctvType { get; set; } = 1;  // 1 : HLS, 2:mp4, 3:img, 4:HLS(https), 5:mp4(https)

        public double MinX { get; set; }

        public double MaxX { get; set; }

        public double MinY { get; set; }

        public double MaxY { get; set; }

        public string GetRetType { get; set; } = "json";
    }
}

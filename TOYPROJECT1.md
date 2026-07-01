# 웹 통합 토이 프로젝트

## 국가교통정보센터 CCTV 정보앱

### 개요

#### 로그인 후 인증키 신청

- 오픈데이터 > 오픈데이터 목록 > CCTV 화상자료
- 인증키 신청 버튼

##### 마이페이지 확인

#### Visual Studio 

##### WPF 프로젝트 생성

##### 동영상 플레이 라이브러리

- 실시간 스트리밍(HLS), 동영상(mp4) 모두 재생이 가능한 라이브러리 필요
- WPF MediaElement - HLS 재생 어려움. mp4 가능. 별도 이미지처리
- WebView2 - HLS 확인필요, mp4 가능, 이미지 가능
- FFME - HLS, mp4 가능. 이미지 별도
- `LibVLCSharp`.WPF - HLC, mp4 가능. 이미지 별도

##### VLC

VideoLAN Organization에서 제공하는 크로스 플랫폼 멀티미디어 재생툴

스트리밍, 동영상 재생 가능

[링크](https://www.videolan.org/)

##### NuGet 패키지 설치

- Newtonsoft.Json
- LibVLCSharp.WPF
- VideoLAN.

### 화면 UI

#### 와이어프레임

### 기본 구현

#### 메인화면 디자인

#### 앱 구조 설계

- Common - 공통 함수나 공통 변수 네임스페이스(폴더)
- Models - OpenAPI Json 데이터 구조 모델 클래스 네임스페이스
- Services - OpenAPI 서비스 동작 클래스 네임스페이스

##### 앱 구조별 구현

- Common/AppCommon.cs - [소스](./toyproject/ToyProjects01/WpfCctvMonitorApp/Common/AppCommon.cs)
- Models/CctvInfo.cs - [소스](./toyproject/ToyProjects01/WpfCctvMonitorApp/Models/CctvInfo.cs)
- Services/ItsCctvService.cs - [소스](./toyproject/ToyProjects01/WpfCctvMonitorApp/Services/ItsCctvService.cs)

##### 화면에 VLC 라이브러리 추가

```xml
<!-- vlc 네임스페이스 추가 -->
<Window x:Class="WpfCctvMonitorApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:vlc="clr-namespace:LibVLCSharp.WPF;assembly=LibVLCSharp.WPF"
        ... >

...
<!-- CCTV 영상영역 border -->
<vlc:VideoView x:Name="VideoView" />
```

##### 기본구현

- 로딩 후 스트리밍 테스트

##### 비즈니스 로직에 구현

type 실시간, 동영상, 정지영상 모두 같은 CCTV를 표현하는 방법만 다름

0. App.config 에서 API key 로드
1. 고속도로 선택
2. 지역 검색 - 지역별 최소/최대 위도, 최대/최소 경도 확인
3. 상세필터 - 시/도로 최대/최소 위도와 경도 확인.  (노선, 방향은 삭제)
4. 검색 - OpenAPI URL로 위경도 범위별 CCTV 조회
5. CCTV 목록 - 리스트
6. 리스트아이템 클릭 - CCTV영상 플레이
7. 지도 영역 - CCTV 위치 지도위 표시
8. CCTV 정보 - json 결과 추출 표시
# 2026 닷넷 개발자 데스크톱 개발

## 2. Unity 실습

### 2.1. 유니티 학습





#### Get Started with Unity

#### 오브젝트 위치(Position), 회전(Rotation), 크기(Scale) 조정

- Inspector에서 Position x,y,z 값을 입력 또는 마우스로 좌우 드래그 형태로 변경
- Rotation, Scale 동일하게 적용

#### Kid's Room 꾸미기

- 방 오브젝트
- 침대, 협탁, 알람시계, 침실조명등 위치 및 회전, 크기 조정

#### Material

- 오브젝트 재질 표현 객체
- Material 객체 생성 후 Inspector에서 조정

- Material 객체를 Ball 객체에 드래그

#### RigidBody

- 물리역학 기능 제공 컴포넌트
- Ball 선택 Inspector에서 Add Component 버튼 클릭

#### Physics Material

- 물체가 충돌할 때 마찰력, 반발력을 설정하는 자산
- Bounciness : 1 완전 탄성 충돌
  - 0.1(쇠구슬), 0.7(축구공), 0.9(고무공)

#### Ramp Object 추가

- 위치, 회전 지정
- Mesh Collider 컴포넌트 추가

#### Block 객체 생성

- Cube로 생성
- Scale x,y,z를 0.1, 0.25, 0.1로 설정, Ball이 튕겨서 닿는 위치에 
- Rigid Body 추가

#### 카메라 시점 변환

- Flythrough 모드로 이동 후
- 카메라 오브젝트 선택
- Ctrl+Shift+F : 현 카메라 시점을 플레이 카메라 시점으로 변경

#### 프리팹 변경

- Prefabs 폴더 내에 기존 Object 드래그하면 Prefab으로 변경

#### Block 쌓기

- Pivot을 Center로 변경 후
- 프리팹 Block을 쌓아올림

#### 프리팹 편집모드

- 프로젝트 창의 프리팹을 더블클릭
- Inspector 수정
- RigidBody > mass를 1보다 작게 수정(0.1)
- 충돌하는 물체의 mass에 상대적 반응
- Hierarchy 창의 < 버튼 클릭

#### 라이트, 스카이박스 조정

- 라이트
- y, z 축으로 낮밤 조정 가능
- Emission > Color 조정 빛 색상조절
  - Emission > Light Appearance, Filter and Temperature 선택후
  - 빛의 온도를 설정

- 스카이박스
  - 하늘 전체 배경 변경
  - Materials > Skyboxes의 Material을 씬뷰에 드래그


#### 플레이모드 구분짓기

- Preferences > Colors > Play mode tints 색상을 어두운색으로 변경
- Play시 UI 색상이  Edit모드와 다르게 표시

#### 피벗기능

- Object를 쌓을때 v를 누르면 Object의 기준점 변경됨


#### Chapter 3 Audio Effect

- 냄비 프리팹 선택, 가스레인지 위 위치
- Audio Source 컴포넌트 추가
- Auido Generator 선택, Loop 체크
- Spatial Blend : 2D

#### 배경음악, 새소리

- 계층창에서 Audio Source 선택
- 알맞은 사운드 Audio Generator에 선택
- 시작하면서 바로 음악 플레이하고 시픙면
  - Play on Awake 체크
- 새소리처럼 랜더마게 플레이하고 싶으면
  - Play on Awake 체크해제
  - PlaySoundAtRandomIntervals 스크립트 추가
  - Min/Max Seconds 랜덤시간 지정

#### Chapter 4. Programming
- 유니티 개발시 가장 핵심!


#### 카메라 플레이어 Child 지정

- Main Camera, Player 하위로 드래그
- 카메라 위치 Reset 뒤 위치, 회전 수정

- 방 아래 Cube까지 화면에 출력. 위치 조정 잘 해줘야 플레이시 카메라 진동X

#### 플레이모드 변수값 변경

- Speed : 5.0f, RotationSpeed : 120.0f
- 플레이시 이동속도가 빠름
- 플레이모드 변수값 수정하면서 알맞은 속도 화인
- Speed : 0.3f, RotationSpeed : 70.0f 이 적당함
- Inspector에 지정된 스크립트 Reset

#### 아이템 코인 오브젝트

- Prefab 폴더에서 Collectible Coin 드래그, 위치, 사이즈 조정
- Collectible.cs 스크립트 생성
```cs
public class Collectible : MonoBehaviour
{
    [Header("회전 설정")]
    [Tooltip("프레임당 회전 속도")]
    [Range(1,10)]
    public float rotationSpeed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
```

#### 아이템 획득 기능 추가

- Coin에 Box Collider > `Is Trigger` 체크
- 충돌은 발생하지 않고, 충돌감지 기능 활성화

- Collectible.cs에 OnTriggerEnter 메서드 추가

```cs
// 물체까지 충돌이 발생했을때 이벤트 처리
private void OnTriggerEnter(Collider other)
{
  Destroy(gameObject);
}
```

#### 점프기능 추가

### 2.2. Unity Factory

- Unity Technologies Japan에서 제공하는 무료 HDRP 공장 시뮬레이션 에셋
- 공장건물부터 컨베이어라인, 로봇팔, 작업자, 조명...
- https://assetstore.unity.com/ 에서 `Unity Factory`검색

### 2.2. 3D 모델 불러오기

#### 렌더링 파이프라인

- 오브젝트 생성, 카메라 확인, 빛 계산, 그림자 계산, 재질 생성/계산, 후처리 후 모니터 출력 등의 순서과정

#### Built-in /SRP
- Built-in - Unity가 렌더링 방식 고정. 수정 어려움
- SRP(Scriptable Render Pipeline) - Unity는 뼈대만 제공, 개발자가 원하는 렌더링을 추가하는 방식

#### 프로젝트 구분

- 렌더링  파이프라인 종류 3가지 구분

|종류 | 성능 | 그래픽품질 | 모바일/VR지원 |
|---|---|---|---|
|Built-in | 보통 | 보통 | 보통 |
|URP | 좋음 | 좋음 | 좋음 |
|HDRP | 낮음(고사양) | 매우 좋음 | 제한적 |

- 기본적으로 Built-in으로 학습

- 에셋스토어에서 제공하는 에셋의 RP 종류 확인하고 사용할 것

#### 3D 모델 활용방법

- 유니티에서는 3D 모델링이 아주 제한적
- 3D 모델 활용방법
  - Blender 무료 3D 모델링 툴에서 작업한 모델 import
  - 3D Max, Rhino 사용 모델링 투 작업 모델 import
  - Unity Asset Store에서 제공하는 3D 모델 import
  - 생성형 AI로 모델 생성 import

#### 3D 모델 가져오기

- https://www.cgtrader.com 에서 검색
- https://poly.pizza/ 
- https://sketchfab.com/


- 호환되는 파일 포맷 
  - `FBX` : Autodesk 3D(AutoCAD) 교환 포맷. Unity 가장 호환
  - `OBJ` : 범용 정적 모델 포맷, Unity 사용 가능
  - STL : 3D 프린터용 포맷, 비추천
  - BLEND : Blender 원본 파일, 애니메이션 기능 포함. 가능(Blender 설치)
  - 3DS : 구형 AutoDesk 3D Studio 모델, 사용 가능

- 스케치팹 사이트 > Conveyor Belt 검색 > 로그인 후 다운로드

- 압축해제, fbx, 텍스처를 프로젝트 Assets 폴더 아래 이동

- Models 폴더에 위치한 Conveyor를 Scene뷰에 드래그

### 2.3. 생산라인


#### 생산품 박스 

- Cube 오브젝트로 생성
- 구글에서 `Plastic Normal Map` 검색
- 텍스쳐 이미지 저장 > Assets > Textures 아래 위치
- Material 생성, Base Map 앞 사각형에 텍스처를 드래그 
- Rigid Body 추가

#### 컨베이어 벨트 물리 컴포넌트

- Belt 에만 Collider 추가
  - Mesh Collider : 3D 모델 폴리곤 메시 개수만큼 충돌영역지정. 리소스 부하
  - `Box Collider` : 큐브형태로 충돌영역지정. 부하적음

#### 컨베이어 벨트 스크립트

- ConveyorBelt.cs 스크립트 생성
- 충돌이 감지되는 동안 물체이동 로직

- 컨베이어 오브젝트 중 Collider 컴포넌트 적용한 벨트에 스크립트 할당
- 플레이 테스트 후 방향 변경

#### Box Spawner 생성

- 박스를 일정시간마다 하나씩 생성하도록 하는 기능
- Product 박스, 컨베이어를 프리팹으로 이동
- EmptyObject 생성, 위치를 이전 Product 위치로 지정
- BoxSpawner.cs 스크립트 

#### 컨베이어 벨트 여러개 구성

- 프리팹 드래그 추가

#### 컨베이어 벨트 멈추기 기능

- ConveyorBelt.cs 오픈
- 로직 변경

```cs

```

- 벨트 동작여부 체크 확인

- 컨베이어 끝에 센서가 있다고 가정. Collider 트리거 발생하면 멈춤기능
- 빈 오브젝트 생성 > Sensor 명명
- Sensor 오브젝트  > `Box Collider` 컴포넌트 추가. `Is Trigger` 체크
- `Edit Collider` 아이콘 클릭 위치, 크기 조정

- Sensor Trigger.cs 스크립트 생성
- Sensor 객체에 스크립트 추가
- 콘솔로 변경, 실행

#### 컨베이어, 스폰 기능 동기화
- TODO 

---

### 2.4. ProBuilder

#### 개요 

Unity에서 건물을 손쉽게 만들 수 있도록 도와주는 패키지

#### 설치

- Windows > Package Manager > Unity Registry에서 `Pribuilder` 검색 후 설치

#### 사용법

- 메뉴 Tools > ProBuilder > Create Shape > 오브젝트 선택

- Heirarchy창 > 마우스 오른쪽 > 


#### 프로젝트 생성

- HighDefinition 3D(HDRP) 프로젝트 생성
- My Assets에서 Unity Factory 검색 후 Import


- Import 후 오류 발생
  - SplineContainer 에러
    - Package Manager > Unity Registry, `Splines` 검색 후 설치
  - Input System 오류
    - 키보드, 마우스 입력 시스템이 Unity 6부터 변경
    - 예전 방식 입력시스템 사용
    - Project Settings > Player > Other Settings > Active Input Handling, Old 또는 Both로 변경 후 에디터 재시작


- Global Volume 오브젝트, 사용체크 비활성화


- URP Asset 생성
- 프로젝트창 > Create > Rendering > URP Asset (with...) 선택

- Edit > Project Settings > Graphics > Default Render Pipeline 값을 HDRP 종류에서 위에서 생성한 URP 에셋으로 변경

- Edit > Project Setting > Quality > Render Pipeline Asset을 URD로 변경

- 머티리얼 변환

- Window > Rendering > Render Pipeline Converter 선택
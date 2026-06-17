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
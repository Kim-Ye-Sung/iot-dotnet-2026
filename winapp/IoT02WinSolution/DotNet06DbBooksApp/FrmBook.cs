using MaterialSkin.Controls;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DotNet06DbBooksApp
{
    public partial class FrmBook : MaterialForm
    {
        DatabaseHelper dbHelper;

        public FrmBook()
        {
            InitializeComponent();
        }

        private void FrmBook_Load(object sender, EventArgs e)
        {
            dbHelper = new DatabaseHelper(); // 객체생성

            // 자동으로 컬럼 생성하면 개발자 의도대로 컬럼을 변경할 수 없음
            DgvBooks.AutoGenerateColumns = false;

            InitGrid(); // 데이터그리드뷰 컬럼 초기설정
            InitData(); // division 테이블 데이터 연동

            LoadData(); // 초기화 완료후 전체 데이터 읽어오기
        }

        private void InitData()
        {
            // 책장르 데이터 조회
            string divSql = "SELECT div_code, div_name FROM division";
            DataTable divTable = dbHelper.Select(divSql);

            // 기존 div_code 컬럼위치 인덱스 
            var colIndex = DgvBooks.Columns["div_code"].Index;  //아마 2

            // 기존 DataGridViewTextBoxColumn으로 생성된 컬럼 제거
            DgvBooks.Columns.RemoveAt(colIndex);

            // 콤보박스컬럼 새로 생성
            DataGridViewComboBoxColumn colCboDivCode = new DataGridViewComboBoxColumn
            {
                Name = "div_code",
                HeaderText = "책장르",
                DataPropertyName = "div_code",
                // 연동되는 데이터 설정
                DataSource = divTable,
                ValueMember = "div_code",
                DisplayMember = "div_name",
            };

            // 기존 div_code 컬럼 위치에 추가
            DgvBooks.Columns.Insert(colIndex, colCboDivCode);
            DgvBooks.Columns["div_code"].ReadOnly = false;
        }

        private void InitGrid()
        {
            // 7개 컬럼을 설정
            // book_idx
            DataGridViewTextBoxColumn colBookIdx = new DataGridViewTextBoxColumn
            {
                Name = "book_idx",
                HeaderText = "순번",   // 화면표시컬럼명
                DataPropertyName = "book_idx",
                Width = 68,
                ReadOnly = true // PK는 수정하면 안됨!!
            };
            DgvBooks.Columns.Add(colBookIdx);

            // author
            DataGridViewTextBoxColumn colAuthor = new DataGridViewTextBoxColumn
            {
                Name = "author",
                HeaderText = "저자",   // 화면표시컬럼명
                DataPropertyName = "author",
                Width = 215,
            };
            DgvBooks.Columns.Add(colAuthor);

            DataGridViewTextBoxColumn colDivCode = new DataGridViewTextBoxColumn
            {
                Name = "div_code",
                HeaderText = "책장르",   // 화면표시컬럼명
                DataPropertyName = "div_code",
                Width = 100,
            };
            DgvBooks.Columns.Add(colDivCode);

            DataGridViewTextBoxColumn colBookName = new DataGridViewTextBoxColumn
            {
                Name = "book_name",
                HeaderText = "책이름",   // 화면표시컬럼명
                DataPropertyName = "book_name",
                Width = 300,
            };
            DgvBooks.Columns.Add(colBookName);

            DataGridViewTextBoxColumn colReleaseDt = new DataGridViewTextBoxColumn
            {
                Name = "release_dt",
                HeaderText = "출판일",   // 화면표시컬럼명
                DataPropertyName = "release_dt",
                Width = 120,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "yyyy-MM-dd"
                }
            };
            DgvBooks.Columns.Add(colReleaseDt);

            DataGridViewTextBoxColumn colIsbn = new DataGridViewTextBoxColumn
            {
                Name = "isbn",
                HeaderText = "ISBN",   // 화면표시컬럼명
                DataPropertyName = "isbn",
                Width = 140,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                }
            };
            DgvBooks.Columns.Add(colIsbn);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn
            {
                Name = "price",
                HeaderText = "가격",   // 화면표시컬럼명
                DataPropertyName = "price",
                Width = 120,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "#,##0"
                }
            };
            DgvBooks.Columns.Add(colPrice);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // SQL 쿼리문 작성
            string query = "SELECT book_idx, author, div_code, book_name, release_dt, isbn, price" +
                           "  FROM books";

            // DataGridView 컨트롤내 DataSource : DataTable 객체를 할당
            DgvBooks.DataSource = dbHelper.Select(query);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var insRes = 0;

                foreach (DataGridViewRow row in DgvBooks.Rows)
                {
                    if (row.IsNewRow) continue;

                    string bookIdx = row.Cells["book_idx"].Value?.ToString();

                    // book_idx가 비어있으면 새로운 레코드 추가
                    if (string.IsNullOrWhiteSpace(bookIdx))
                    {
                        string author = row.Cells["author"].Value?.ToString();
                        string divCode = row.Cells["div_code"].Value?.ToString();
                        string bookName = row.Cells["book_name"].Value?.ToString();

                        string releaseDt = "";

                        if (row.Cells["release_dt"].Value != null)
                        {
                            DateTime dt = Convert.ToDateTime(row.Cells["release_dt"].Value);
                            releaseDt = dt.ToString("yyyy-MM-dd");
                        }

                        string isbn = row.Cells["isbn"].Value?.ToString();
                        string price = row.Cells["price"].Value?.ToString();

                        string inSql = "INSERT INTO bookrentalshop.books " +
                                       "(author, div_code, book_name, release_dt, isbn, price) " +
                                       $"VALUES ('{author}', '{divCode}', '{bookName}', '{releaseDt}', '{isbn}', '{price}')";

                        dbHelper.Execute(inSql);

                        insRes++;
                    }
                }

                if (insRes > 0)
                {
                    MessageBox.Show("데이터 추가 완료!");
                }
                else
                {
                    MessageBox.Show("추가할 새 데이터가 없습니다.");
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"INSERT 오류 : {ex.Message}");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var udpRes = 0;

                foreach (DataGridViewRow row in DgvBooks.SelectedRows)
                {
                    string bookIdx = row.Cells["book_idx"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(bookIdx))
                    {
                        string author = row.Cells["author"].Value?.ToString();
                        string divCode = row.Cells["div_code"].Value?.ToString();
                        string bookName = row.Cells["book_name"].Value?.ToString();

                        string releaseDt = "";

                        if (row.Cells["release_dt"].Value != null)
                        {
                            DateTime dt = Convert.ToDateTime(row.Cells["release_dt"].Value);
                            releaseDt = dt.ToString("yyyy-MM-dd");
                        }

                        string isbn = row.Cells["isbn"].Value?.ToString();
                        string price = row.Cells["price"].Value?.ToString();

                        string upSql = "UPDATE books " + $"SET author='{author}', " +
                                        $"div_code='{divCode}', " +
                                        $"book_name='{bookName}', " +
                                        $"release_dt='{releaseDt}', " +
                                        $"isbn='{isbn}', " +
                                        $"price='{price}' " +
                                        $"WHERE book_idx={bookIdx}";

                        udpRes += dbHelper.Execute(upSql);
                    }
                }

                if (udpRes > 0)
                {
                    MessageBox.Show($"{udpRes}건의 데이터가 수정되었습니다.");
                }
                else
                {
                    MessageBox.Show("수정 실패!");
                }
                LoadData(); // 데이터 변경로드
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(DgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            }

            DialogResult result = MessageBox.Show($"{DgvBooks.SelectedRows.Count}건 삭제하시겠습니까?", "삭제 확인",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            var delRes = 0;

            if(result == DialogResult.Yes)
            {
                // 삭제 진행
                foreach (DataGridViewRow row in DgvBooks.SelectedRows)
                {
                    string bookIdx = row.Cells["book_idx"].Value?.ToString();

                    if(string.IsNullOrWhiteSpace(bookIdx))
                    {
                        // 책번호PK가 없으면 패스
                        continue;
                    }

                    string delSql = $"DELETE FROM books WHERE book_idx = {bookIdx}";

                    delRes += dbHelper.Execute(delSql);
                }

                MessageBox.Show($"{delRes}건 삭제 완료!");
                LoadData();
            }
        }
    }
}

        public class ClubesController : Controller
        {
            private readonly AppDbcontext _context;
            public ClubesController(AppDbcontext context)
            {
                _context = context;
            }

        public async Task<IActionResult> Index(string sortBy, string sortDirection, string série)
        {
            var dados = await _context.Clubes.ToListAsync();

            // Realize a classificação dos dados com base no valor de sortBy.
            if (!string.IsNullOrEmpty(sortBy))
            {
                dados = SortData(dados, sortBy, sortDirection);
            }

            // Obtenha a lista completa de séries antes de aplicar o filtro
            var todasAsSéries = dados.Select(x => x.Série).Distinct().ToList();

            // Filtrar por Série, se especificado
            if (!string.IsNullOrEmpty(série))
            {
                dados = dados.Where(x => x.Série == série).ToList();
            }

            // Adicione as séries no ViewBag para serem acessadas na view
            ViewBag.TodasAsSéries = todasAsSéries;
            ViewBag.SérieSelecionada = série;

            return View(dados);
        }


        private List<Clube> SortData(List<Clube> data, string sortBy, string sortDirection)
        {
            if (sortDirection == "asc")
            {
                switch (sortBy)
                {
                    case "Nome":
                        return data.OrderBy(item => item.Nome).ToList();
                    case "Estado":
                        return data.OrderBy(item => item.Estado).ToList();
                    case "Série":
                        return data.OrderBy(item => item.Série).ToList();

                    case "gols2021":
                        return data.OrderBy(item => item.gols2021).ToList();
                    case "gols2022":
                        return data.OrderBy(item => item.gols2022).ToList();
                    case "gols2023":
                        return data.OrderBy(item => item.gols2023).ToList();
                    default:
                        return data;
                }
            }

            else if (sortDirection == "desc")
            {
                switch (sortBy)
                {
                    case "Nome":
                        return data.OrderByDescending(item => item.Nome).ToList();
                    case "Estado":
                        return data.OrderByDescending(item => item.Estado).ToList();
                    case "Série":
                        return data.OrderByDescending(item => item.Série).ToList();

                    case "gols2023":
                        return data.OrderByDescending(item => item.gols2023).ToList();
                    case "gols2022":
                        return data.OrderByDescending(item => item.gols2022).ToList();
                    case "gols2021":
                        return data.OrderByDescending(item => item.gols2021).ToList();

                    default:
                        return data;
                }
            }

            else
            {
                return data;
            }
        }


        public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Clube clube)
            {
                if (ModelState.IsValid)
                {
                    _context.Clubes.Add(clube);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(clube);
            }

            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                    return NotFound();

                var dados = await _context.Clubes.FindAsync(id);

                if (dados == null)
                    return NotFound();


                return View(dados);
            }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Clube clube)
        {
            if (id != clube.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Clubes.Update(clube); 
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clube); 
        }


        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                    return NotFound();

                var dados = await _context.Clubes.FindAsync(id);

                if (dados == null)
                    return NotFound();


                return View(dados);

            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                    return NotFound();

                var dados = await _context.Clubes.FindAsync(id);

                if (dados == null)
                    return NotFound();


                return View(dados);
            }

            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int? id)
            {
                if (id == null)
                    return NotFound();

                var dados = await _context.Clubes.FindAsync(id);

                if (dados == null)
                    return NotFound();

                _context.Clubes.Remove(dados);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
        private object GetPropertyValueByColumnName(Atacante item, string columnName)
        {
            var prop = typeof(Atacante).GetProperty(columnName);
            if (prop != null)
            {
                return prop.GetValue(item, null);
            }
            return null;
        }
    }
}


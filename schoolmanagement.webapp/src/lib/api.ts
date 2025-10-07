const API_BASE = process.env.NEXT_PUBLIC_API_BASE ?? 'http://localhost:5000';

async function request(path: string, options: RequestInit = {}) {
  const token = typeof window !== 'undefined' ? localStorage.getItem('token') : null;
  const headers: Record<string, string> = { 'Content-Type': 'application/json', ...(options.headers || {}) };
  if (token) headers['Authorization'] = `Bearer ${token}`;
  const res = await fetch(`${API_BASE}${path}`, { ...options, headers });
  if (!res.ok) {
    const text = await res.text().catch(()=>null);
    let data = null;
    try { data = JSON.parse(text); } catch {}
    const msg = data?.mensagem || data?.message || text || res.statusText;
    const error = new Error(msg);
    (error as any).status = res.status;
    throw error;
  }
  return res.status === 204 ? null : res.json();
}

export async function login(email: string, senha: string, perfil: string) {
  return request('/api/auth/login', {
    method: 'POST',
    body: JSON.stringify({ email, senha })
  });
}

export async function listarEscolas() {
  return request('/api/escolas');
}

export async function listarMensalidadesPorEscola(escolaId: number) {
  return request(`/api/escolas/${escolaId}/mensalidades`);
}

export async function listarParcelasDoResponsavel(responsavelId: number) {
  return request(`/api/responsaveis/${responsavelId}/parcelas`);
}

export async function marcarParcelaComoPaga(parcelaId: number) {
  return request(`/api/parcelas/${parcelaId}/pagar`, { method: 'POST' });
}
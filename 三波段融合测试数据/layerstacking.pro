pro ENVI_LAYER_STACKING_DOIT_Record,_extra = extra
end
pro LayerStacking,paths,out_path

  compile_opt idl2

  ;严格编译规则
  compile_opt idl2
  ;载入envi的sav文件
  envi,/restore_base_save_files
  ;初始化envi
  envi_batch_init,log_file = 'batch.LOG'
  fids = lonarr(n_elements(paths))
  nbs = lonarr(n_elements(paths))
  nses = lonarr(n_elements(paths))
  nls = lonarr(n_elements(paths))
  dimses = lonarr(5,n_elements(paths))
  Sum_nb = 0l
  for i = 0,n_elements(paths)-1 do begin
    envi_open_file,paths[i],r_fid =r_fid
    fids[i] = r_fid
    envi_file_query,fids[i],ns=ns, nl=nl, nb=nb,dims = dims
    nses[i]=ns
    nls[i]=nl
    nbs[i]=nb
    dimses[*,i]=dims
    Sum_nb = Sum_nb + nbs[i]
  endfor
  pos = lonarr(Sum_nb)
  out_proj = envi_get_projection(fid=fids[0],pixel_size=out_ps)
  ENVI_DOIT,'ENVI_LAYER_STACKING_DOIT',dims=dimses,FID=fids,pos=pos,OUT_NAME=out_path,$
    out_dt=4,interp=2, out_ps=out_ps, $
    out_proj=out_proj, r_fid=r_fid
end
<?php if($resultadoensayo->getEnsayook()==0){?>
  <?php echo $resultadoensayo->getError(); ?> (en paso <?php echo $resultadoensayo->getPaso(); ?>)
<?php }else{?>
  No hubo errores.
<?php }?>
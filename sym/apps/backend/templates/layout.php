<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
  <head>
    <link rel="shortcut icon" type="image/ico" href="/images/favico.ico" />
    <?php include_http_metas() ?>
    <?php include_metas() ?>
    <?php include_title() ?>
    <?php jq_add_plugin(array( 'jquery-ui-1.7.2.custom.min.js')); ?>
    <link rel="shortcut icon" href="/favicon.ico" />
    <?php include_stylesheets() ?>
    <?php include_javascripts() ?>
  
    <script type="text/javascript">
    
    function ask_password(obj)
    {
      var pwd = prompt ("Ingrese nueva contraseña");
      if( pwd == '' )
        return false;
        
      $.ajax({
        url: $(obj).attr('href') + '?newpass='+pwd,
        success: function ( e ) {
          alert('La contraseña fue cambiada correctamente');
        },
        error : function (e ) {
          alert('Se produjo un error intentando cambiar la contraseña');
        }
      });
      
      return false;
    }
    
    jQuery(document).ready(function(){
      if(jQuery('#sf_admin_bar .sf_admin_filter').length<1)
        return;
      jQuery('#sf_admin_bar').prepend('<a href="#" id="hide_show_filter" style="float:right;margin:4px 4px 4px 4px;" onclick="return hideFilter();">Ocultar</a>');
      hideFilter();
    });
    function hideFilter(){
      jQuery('#sf_admin_bar .sf_admin_filter').toggle();
      jQuery('#sf_admin_bar').toggleClass('sf_admin_filter_hidden');
      if(jQuery('#hide_show_filter').html()=='Ocultar')
      { jQuery('#hide_show_filter').html('Filtro');}
      else
      { jQuery('#hide_show_filter').html('Ocultar');}
      return false;
    }
  </script>

  </head>
  <body>
    <?php include_partial('sfAdminDash/header') ?>
    <?php echo $sf_content ?>
    <?php include_partial('sfAdminDash/footer') ?>
  </body>
</html>

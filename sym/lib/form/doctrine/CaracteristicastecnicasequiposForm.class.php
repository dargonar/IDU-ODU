<?php

/**
 * Caracteristicastecnicasequipos form.
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormTemplate.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class CaracteristicastecnicasequiposForm extends BaseCaracteristicastecnicasequiposForm
{
  public function configure()
  {
    parent::configure();
    unset($this['caracteristicastecnicasequipos_version']);
    unset($this['caracteristicastecnicasequipos_descripcion1']);
    unset($this['caracteristicastecnicasequipos_descripcion2']);
    unset($this['caracteristicastecnicasequipos_descripcion3']);
    unset($this['caracteristicastecnicasequipos_descripcion4']);
    unset($this['caracteristicastecnicasequipos_descripcion5']);
    unset($this['caracteristicastecnicasequipos_descripcion6']);
    unset($this['caracteristicastecnicasequipos_tensionnominal']);
    unset($this['caracteristicastecnicasequipos_frecuencia']);
    unset($this['caracteristicastecnicasequipos_potenciamaxima']);
    unset($this['caracteristicastecnicasequipos_corrientemaxima']);
    unset($this['caracteristicastecnicasequipos_carga']);
    unset($this['caracteristicastecnicasequipos_presion']);
    unset($this['caracteristicastecnicasequipos_capacidadfrio']);
    unset($this['caracteristicastecnicasequipos_potencianominalfrio']);
    unset($this['caracteristicastecnicasequipos_corrientenominalfrio']);
    unset($this['caracteristicastecnicasequipos_peso']);
    unset($this['caracteristicastecnicasequipos_capacidadcalor']);
    unset($this['caracteristicastecnicasequipos_potencianominalcalor']);
    unset($this['caracteristicastecnicasequipos_corrientenominalcalor']);
    unset($this['caracteristicastecnicasequipos_err']);
    //unset($this['caracteristicastecnicasequipos_esidu']);
    //unset($this['caracteristicastecnicasequipos_nombre']);
    unset($this['caracteristicastecnicasequipos_idparametros']);
    //unset($this['caracteristicastecnicasequipos_idparametros_idu']);
    //unset($this['caracteristicastecnicasequipos_idparametros_odu']);
    unset($this['es_activo']);
    
    $this->widgetSchema['caracteristicastecnicasequipos_nombre'] = new sfWidgetFormInputText();
    $this->validatorSchema['caracteristicastecnicasequipos_nombre'] = new sfValidatorString(array('max_length' => 100, 'required' => false));
  }
}

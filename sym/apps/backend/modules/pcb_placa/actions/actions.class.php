<?php

require_once dirname(__FILE__).'/../lib/pcb_placaGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/pcb_placaGeneratorHelper.class.php';

/**
 * pcb_placa actions.
 *
 * @package    sf_sandbox
 * @subpackage pcb_placa
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class pcb_placaActions extends autoPcb_placaActions
{

  public function executeListEnsayo(sfWebRequest $request){
    $placa = $this->getRoute()->getObject();
    
    // $filters = $this->getUser()->getAttribute('ensayo.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    // $filters['id'] = array('text'=>$placa->getEnsayoId());
    // $this->getUser()->setAttribute('ensayo.filters', $filters, 'admin_module');
    $this->redirect(array('sf_route' => 'ensayo_edit', 'sf_subject' => $placa->getEnsayo()));
    
  }
  
  public function executeListEtiqueta(sfWebRequest $request){
    $placa = $this->getRoute()->getObject();
    
    // $filters = $this->getUser()->getAttribute('etiqueta.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    // $filters['id'] = array('text'=>$placa->getEtiquetaId());
    // $this->getUser()->setAttribute('etiqueta.filters', $filters, 'admin_module');
    // $this->redirect("etiqueta");
    $this->redirect(array('sf_route' => 'etiqueta_edit', 'sf_subject' => $placa->getEtiqueta()));
  }
  
  public function executeListVersion(sfWebRequest $request)
  {  
    $placa = $this->getRoute()->getObject();
    
    // $filters = $this->getUser()->getAttribute('version.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    // $filters['id'] = array('text'=>$placa->getVersionId());
    // $this->getUser()->setAttribute('version.filters', $filters, 'admin_module');
    // $this->redirect("version");
    $this->redirect(array('sf_route' => 'version_edit', 'sf_subject' => $placa->getVersion()));
  }
  
}
